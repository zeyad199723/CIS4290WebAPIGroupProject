Imports System.Web.Http

Namespace Controllers
    Public Class PaymentController
        Inherits ApiController
        Private ReadOnly UserRepository As New UserRepository()
        Private ReadOnly CreditCardRepository As New CreditCardRepository()

        Private Function GenerateAuthorizationCode() As String
            Dim authRandom = New Random()
            Const codeChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            Dim authCode As New StringBuilder()

            For codeLength As Integer = 1 To 15
                authCode.Append(codeChars(authRandom.Next(codeChars.Length)))
            Next

            Return authCode.ToString()
        End Function

        <HttpPost>
        <Route("api/payment/processpayment")>
        Public Function ProcessPayment(<FromBody> data As PaymentRequest) As IHttpActionResult

            Using dbContext As New Customer_DBContext()
                    Dim user = UserRepository.AuthenticateUser(dbContext, data.LoginID, data.TransactionKey)
                    If user IsNot Nothing Then
                        Dim creditCard = CreditCardRepository.ValidateCreditCard(dbContext, data.CardNumber)

                        If creditCard IsNot Nothing AndAlso Not creditCard.OnHold AndAlso creditCard.CreditFund >= data.Amount Then

                            Dim onHold As Integer = creditCard.OnHold

                            If onHold = 1 Then
                                Return Ok(New PaymentResponse() With {.Status = "Declined", .Message = "Credit card is on hold"})
                            ElseIf onHold = 0 Then

                                Dim authCode As String = GenerateAuthorizationCode()
                                Return Ok(New PaymentResponse() With {.Status = "Success", .AuthorizationCode = authCode, .Message = "Payment successful"})
                            Else

                                Return Ok(New PaymentResponse() With {.Status = "Error", .Message = "Unknown card error"})
                            End If
                        Else
                            Return Ok(New PaymentResponse() With {.Status = "Declined", .Message = "Invalid card number or insufficient funds"})
                        End If
                    Else
                        Dim authCode As String = GenerateAuthorizationCode()
                        Return Ok(New PaymentResponse() With {.Status = "Error", .AuthorizationCode = authCode, .Message = "Invalid user"})
                    End If
                End Using

        End Function

    End Class
End Namespace