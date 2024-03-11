Public Class PaymentRequest
    Public Property LoginID As String
    Public Property TransactionKey As String
    Public Property CardNumber As String
    Public Property CardHolder As String
    Public Property ExpirationDate As String
    Public Property SecurityCode As String
    Public Property OnHold As Integer
    Public Property Amount As Decimal
End Class
Public Class PaymentResponse
    Public Property Status As String
    Public Property AuthorizationCode As String
    Public Property Message As String
End Class
