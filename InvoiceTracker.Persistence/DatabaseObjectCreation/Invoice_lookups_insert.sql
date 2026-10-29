USE [INV_assessment]

Insert into dbo.AccountingType([description], CreatedDate, Isdeleted)
values
('Debit', getdate(),0),
('Credit', getdate(),0)

Insert into dbo.InvoiceStatus([description], CreatedDate, Isdeleted)
values
('Pending', getdate(),0),
('Rejected', getdate(),0),
('Approved', getdate(),0),
('Paid', getdate(),0)


Insert into dbo.TransactionType([description], CreatedDate, Isdeleted)
values
('Invoice', getdate(),0),
('CreditNote', getdate(),0),
('Payment', getdate(),0)




insert into dbo.NotificatonType([Description],CreatedDate,IsDeleted)
values
('Email', getdate(),0),
('Slack', getdate(),0)



insert into dbo.EscalationGroup([Description],NotificatonTypeId,NotificatonIdentifier,IsDeleted)
values('Admin',1,'admin@assessment.co.za',0),
('Managers',1,'managers@assessment.co.za',0),
('SeniorManagers',2,'seniormanager-invoices',0)


select * from dbo.InvoiceStatus

insert into dbo.InvoiceSLAEscalation(
InvoiceStatusId,
MinNumberOfDays,
MaxNumberOfDays,
EscalationGroupId,
createdDate,
IsDeleted 
)
values
(1,1,2,1,getdate(),0),
(1,3,4,2,getdate(),0),
(1,5,10,3,getdate(),0),
(3,1,2,1,getdate(),0),
(3,3,4,2,getdate(),0),
(3,5,10,3,getdate(),0)
