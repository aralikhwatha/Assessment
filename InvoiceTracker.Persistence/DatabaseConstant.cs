namespace InvoiceTracker.Persistence
{
    public static class DatabaseConstant
    {
        public const string CreateInvoiceSql = @"INSERT INTO [dbo].invoice (InvoiceStatusId,VendorId,PaymentDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted) OUTPUT INSERTED.invoiceId VALUES (@InvoiceStatusId,@VendorId,@PaymentDate, @CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate, @IsDeleted);";
        public const string CreateInvoiceLineItemSql = @"Insert into dbo.InvoiceLineItem(InvoiceId,[Description],Quantity,UnitPrice,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted) values(@InvoiceId,@Description,@Quantity,@UnitPrice,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate, @IsDeleted)";
        public const string CreateInvoiceTransactionSql = @"Insert into dbo.[Transaction](TransactionTypeId,AccountingTypeId,InvoiceId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted) values(@TransactionTypeId,@AccountingTypeId,@InvoiceId,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate, @IsDeleted)";
        public const string CreateInvoicePaymentEntrySql = @"Insert into dbo.InvoicePayment(InvoiceId,Amount,CreatedBy,CreatedDate,IsDeleted) OUTPUT INSERTED.InvoicePaymentId values(@InvoiceId,@Amount,@CreatedBy,@CreatedDate, @IsDeleted)";

        public const string GetInvoiceSql = @"select InvoiceId,InvoiceStatusId ,VendorId,PaymentDate,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted from dbo.Invoice where InvoiceId = @invoiceId and IsDeleted=0;";
        public const string GetUnpaidInvoicesSql = @"select invoiceId, PaymentDate, InvoiceStatusId from dbo.Invoice where InvoiceStatusId in (1) and DATEDIFF(day,PaymentDate, GetDate()) >= @minNumberOfDays and DATEDIFF(day,PaymentDate, GetDate()) <= @maxNumberOfDays and IsDeleted=0";
        public const string GetInvoiceEscalationRulesSql = @"select InvoiceStatusId, MinNumberOfDays,MaxNumberOfDays, EscalationGroupId from dbo.InvoiceSLAEscalation where IsDeleted = 0";
        public const string GetInvoiceEscalationGroupsSql = @"select EscalationGroupId, [Description], NotificatonTypeId As NotificationChannel, NotificatonIdentifier As NotificationChannelIdenfier from dbo.escalationgroup where isdeleted = 0";
        public const string GetInvoicePaymentEntrySql = @"select InvoicePaymentId,InvoiceId,Amount,CreatedBy,CreatedDate,IsDeleted from dbo.InvoicePayment where InvoicePaymentId = @paymententryId and isdeleted =0";
        public const string GetInvoiceLineItemsSql = @"select InvoiceLineItemId,InvoiceId,[Description],Quantity,UnitPrice,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted from dbo.InvoiceLineItem where InvoiceId=@invoiceId and IsDeleted =0";

        public const string UpdateInvoiceStatusSql = @"update dbo.Invoice set InvoiceStatusId=@invoiceStatusId, ModifiedBy=@ModifiedBy, ModifiedDate=@ModifiedDate where invoiceId=@invoiceId";




    }
}
