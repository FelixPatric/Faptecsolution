namespace Faptecsolution.CaritasCRM.Domain.Enums
{
    public enum InvoiceStatus
    {
        Draft,          // Just created, not sent
        Sent,           // Sent to customer
        Partial,        // Partially paid
        Paid,           // Fully paid
        Overdue,        // Past due date
        Canceled,       // Canceled
        Refunded        // Refunded to customer
    }


}

