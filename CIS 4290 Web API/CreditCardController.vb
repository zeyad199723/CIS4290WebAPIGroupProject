Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports CIS_4290_Web_API.Models

Namespace Controllers
    <Route("api/[controller]")>
    <ApiController>
    Public Class CreditCardController
        Inherits ControllerBase

        Protected Overrides Sub ExecuteCore()
            Throw New NotImplementedException()
        End Sub

        <HttpPost>
        Public Function Post(ByVal cardInfo As CreditCardInfo) As ActionResult
            ' Add your logic to handle the credit card information here
            Return Ok(New With {
                .Message = "Credit Card Info Received",
                .CardInfo = cardInfo
            })
        End Function

        Private Function Ok(value As Object) As ActionResult
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
