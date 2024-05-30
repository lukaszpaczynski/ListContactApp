﻿global using ListContactApp.Infrastructure.Extensions;
global using ListContactApp.Aplication.Extensions;
global using ListContactApp.MVC.Extensions;
global using ListContactApp.Aplication.Contact.Commands.CreateContact;
global using ListContactApp.Aplication.Contact.Commands.DeleteContact;
global using ListContactApp.Aplication.Contact.Commands.EditContact;
global using ListContactApp.Aplication.Contact.Queries.GetAllContacts;
global using ListContactApp.Aplication.Contact.Queries.GetContactByEmail;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Authorization;
global using ListContactApp.MVC.Middlewares;