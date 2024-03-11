Public Class CreditCardRepository
    Public Function ValidateCreditCard(dbContext As Customer_DBContext, cardNumber As String) As CreditCardInfo
        Return dbContext.CreditCardInfoes.FirstOrDefault(Function(c) c.CardNumber = cardNumber)
    End Function
End Class
