Summary:
Invoice tracking, user captures an invoice, invoice has to be approved and paid.

if an invoice is not paid after the set invoice payment date has passed, invoice goes throgh escalation process(configurable in the database), where notifications are sent the escalation group and channel.

Payments are initiated in the system, however processed outside the system and when payment is done and event will be raised for the invoice tracking system process and update the invoice.

technologies:

.net 8
.Rabbitmq using Masstransit library
Dapper
Ms SQL

database object creation scripts unde invoiceTracker.Persistence/DatabaseObjectCreation
