# Simple Invoicing

Intended for small scale service workers looking to upgrade their Invoicing practices from something simple like Excel or Google-Documents to something more standardized

# Third Party Libraries / Technologies

## Backend and Database Interaction

1. SQL Server
1. EntityFramework Core

## Middleware

1. AutoMapper
1. FluentValidation
1. MediatR
1. Newtonsoft.Json 
1. NSwag 
1. Swashbuckle 
1. VueCliMiddleware

## Front End 

1. VueJS
1. Vuetify
1. Vuex

## General Notes

Firefox sometimes plays a Blocking game with CORS and such making development hard. 
Don't know yet out of the box how to prevent this, but should be adding an exception to it's Safety Blocking mentality.

## Invoices

### ProcessPendingInvoicesAsync

Processing Invoices Means updating them to AR as part of the General Ledger -

- This means that this functionality will have to be apart of a GL Module that will implement an AR and AP
- 
