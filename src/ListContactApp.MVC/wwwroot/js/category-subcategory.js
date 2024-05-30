function updateSubCategories() {
    var category = document.getElementById("Category").value;
    var subCategorySelect = document.getElementById("SubCategory");
    var subCategoryInputGroup = document.getElementById("SubCategoryInputGroup");
    var subCategoryGroup = document.getElementById("SubCategoryGroup");
    var subCategoryInput = document.getElementById("SubCategoryInput");

    subCategorySelect.innerHTML = "";

    if (category === "Work") {
        subCategoryGroup.style.display = "block";
        subCategoryInputGroup.style.display = "none";
        var options = ["Client", "Manager", "Worker"];
        options.forEach(function (option) {
            var opt = document.createElement("option");
            opt.value = option;
            opt.innerHTML = option;
            subCategorySelect.appendChild(opt);
        });
    } else if (category === "Private") {
        subCategoryGroup.style.display = "block";
        subCategoryInputGroup.style.display = "none";
        var options = ["Friend", "Uncle"];
        options.forEach(function (option) {
            var opt = document.createElement("option");
            opt.value = option;
            opt.innerHTML = option;
            subCategorySelect.appendChild(opt);
        });
    } else if (category === "Other") {
        subCategoryGroup.style.display = "none";
        subCategoryInputGroup.style.display = "block";

        if (document.getElementById("Category").getAttribute('data-initial') !== 'Other') {
            subCategoryInput.value = "";
        }
    }

    var currentSubCategory = document.getElementById("CurrentSubCategory").value;
    for (var i = 0; i < subCategorySelect.options.length; i++) {
        if (subCategorySelect.options[i].value === currentSubCategory) {
            subCategorySelect.options[i].selected = true;
            break;
        }
    }

    if (category === "Other") {
        subCategoryInput.value = currentSubCategory;
    }
}

document.addEventListener("DOMContentLoaded", function () {
    var categoryElement = document.getElementById("Category");
    categoryElement.setAttribute('data-initial', categoryElement.value);
    updateSubCategories();
});

document.getElementById("Category").addEventListener("change", updateSubCategories);
