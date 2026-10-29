
USE [INV_assessment]
IF OBJECT_ID('dbo.[Transaction]') IS NOT NULL
    DROP table dbo.[Transaction];
GO

IF OBJECT_ID('dbo.Invoice') IS NOT NULL
    DROP table dbo.Invoice;
GO

IF OBJECT_ID('dbo.InvoiceLineItem') IS NOT NULL
    DROP table dbo.InvoiceLineItem;
GO

IF OBJECT_ID('dbo.Vendor') IS NOT NULL
    DROP table dbo.Vendor;
GO

IF OBJECT_ID('dbo.InvoiceStatus') IS NOT NULL
    DROP table dbo.InvoiceStatus;
GO


IF OBJECT_ID('dbo.TransactionType') IS NOT NULL
    DROP table dbo.TransactionType;
GO

IF OBJECT_ID('dbo.AccountingType') IS NOT NULL
    DROP table dbo.AccountingType;
GO



CREATE TABLE dbo.Vendor(
VendorId INT IDENTITY(1,1) not null,
[Name] VARCHAR(100) not null,
Identifier varchar(50) not null,
[CreatedDate] DATETIME not null,
CreatedBy varchar(10) not null,
IsDeleted bit not null

primary key (VendorId)
)


create table dbo.InvoiceStatus(
InvoiceStatusId int identity(1,1) not null,
[Description] varchar(50) not null,
CreatedDate Datetime not null,
IsDeleted bit not null

primary key (InvoiceStatusId)
)

create table dbo.Invoice(
InvoiceId int identity(1,1) not null,
InvoiceStatusId int not null,
VendorId int not null,
PaymentDate Datetime not null,
CreatedBy varchar(50) not null,
CreatedDate Datetime not null,
ModifiedBy varchar(50) not null,
ModifiedDate Datetime not null,
IsDeleted bit not null

primary key (InvoiceId)

)

ALTER TABLE dbo.Invoice add foreign key(InvoiceStatusId) references dbo.InvoiceStatus(InvoiceStatusId)
ALTER TABLE dbo.Invoice add foreign key(VendorId) references dbo.Vendor(VendorId)

create table dbo.InvoiceLineItem(
InvoiceLineItemId int identity(1,1) not null,
InvoiceId int not null,
[Description] varchar(150) not null,
Quantity int not null,
UnitPrice decimal(15,2) not null,
CreatedBy varchar(50) not null,
CreatedDate Datetime not null,
ModifiedBy varchar(50) not null,
ModifiedDate Datetime not null,
IsDeleted bit not null

primary key (InvoiceLineItemId)

)
ALTER TABLE dbo.InvoiceLineItem ADD foreign key(InvoiceId) references dbo.Invoice(InvoiceId)

create table dbo.TransactionType(
TransactionTypeId int identity(1,1) not null,
[Description] varchar(50) not null,
CreatedDate Datetime not null,
IsDeleted bit not null
primary key (TransactionTypeId)
)

create table dbo.AccountingType(
AccountingTypeId int identity(1,1) not null,
[Description] varchar(10) not null,
CreatedDate Datetime not null,
IsDeleted bit not null

primary key (AccountingTypeId)
)


create table dbo.[Transaction](
TransactionId int identity(1,1) not null,
TransactionTypeId int not null,
AccountingTypeId int not null,
InvoiceId int not null,
CreatedBy varchar(50) not null,
CreatedDate Datetime not null,
ModifiedBy varchar(50) not null,
ModifiedDate Datetime not null,
IsDeleted bit not null

primary key (InvoiceId)


)

ALTER TABLE dbo.[Transaction] ADD foreign key(TransactionTypeId) references dbo.TransactionType(TransactionTypeId)
ALTER TABLE dbo.[Transaction] ADD foreign key(AccountingTypeId) references dbo.AccountingType(AccountingTypeId)
ALTER TABLE dbo.[Transaction] ADD foreign key(InvoiceId) references dbo.Invoice(InvoiceId)

Create table dbo.NotificatonType(
NotificatonTypeId int identity(1,1) not null,
[Description] varchar(100) not null,
CreatedDate Date not null,
IsDeleted bit not null

primary key(NotificatonTypeId)
)


Create table dbo.EscalationGroup(
EscalationGroupId int identity(1,1) not null,
[Description] varchar(100) not null,
NotificatonTypeId int not null,
NotificatonIdentifier varchar(100) not null,
IsDeleted bit not null

primary key(EscalationGroupId)
)

ALTER TABLE dbo.EscalationGroup ADD foreign key(NotificatonTypeId) references dbo.NotificatonType(NotificatonTypeId)


Create table dbo.InvoiceSLAEscalation(
InvoiceSLAEscalationId int identity(1,1) not null,
InvoiceStatusId int not null,
MinNumberOfDays int not null,
MaxNumberOfDays int not null,
EscalationGroupId int not null,
createdDate date not null,
IsDeleted bit not null

primary key(InvoiceSLAEscalationId)
)

ALTER TABLE dbo.InvoiceSLAEscalation ADD foreign key(InvoiceStatusId) references dbo.InvoiceStatus(InvoiceStatusId)
ALTER TABLE dbo.EscalationGroup ADD foreign key(EscalationGroupId) references dbo.EscalationGroup(EscalationGroupId)


create table dbo.InvoicePayment(
InvoicePaymentId int identity(1,1) not null,
InvoiceId int not null,
Amount decimal(15,2) not null,
CreatedBy varchar(50) not null,
CreatedDate Datetime not null,
IsDeleted bit not null

primary key (InvoicePaymentId)

)

ALTER TABLE dbo.InvoicePayment ADD foreign key(InvoiceId) references dbo.Invoice(InvoiceId)