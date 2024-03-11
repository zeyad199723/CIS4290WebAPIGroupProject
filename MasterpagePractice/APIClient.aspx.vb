Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json

Public Class PaymentResponse
    Public Property Status As String
    Public Property AuthorizationCode As String
    Public Property Message As String
End Class
Public Class APIClient
    Inherits System.Web.UI.Page
    Dim httpClient As New HttpClient

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Private Async Sub BtnSendPayment_ClickAsync(sender As Object, e As EventArgs) Handles btnSendPayment.Click
        Dim myJson As String = ("{'LoginID': '" & LoginID.Value & "', 'TransactionKey': '" & TransactionKey.Value & "', 'Name': '" _
            & CardHolder.Value & "', 'CardNumber': '" & CardNumber.Value & "', 'ExpirationDate': '" & ExpirationDate.Value & "', 'SecurityCode': '" & SecurityCode.Value _
            & "', 'Amount': '" & Amount.Value & "'}")

        httpClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", GetToken())
        Dim uri As String = "https://localhost:44395/api/payment/processpayment"
        Dim response = Await httpClient.PostAsync(uri, New StringContent(myJson, Encoding.UTF8, "application/json"))

        If response.IsSuccessStatusCode Then
            Dim responseData As String = Await response.Content.ReadAsStringAsync()
            Dim apiResponse As PaymentResponse = JsonConvert.DeserializeObject(Of PaymentResponse)(responseData)

            If apiResponse IsNot Nothing Then
                If apiResponse.Status = "Success" Then
                    ResponseLbl.Text = $"Payment successful! Authorization Code: {apiResponse.AuthorizationCode}"
                Else
                    ResponseLbl.Text = $"Payment declined due to: {apiResponse.Message}"

                End If
            Else
                ResponseLbl.Text = "Unexpected response format."
            End If
        Else
            ResponseLbl.Text = $"Error: {response.ReasonPhrase}"
        End If
    End Sub
    Private Function GetToken() As String
        Dim jwtToken As String = Nothing

        If Request.Cookies("JwtCookie") IsNot Nothing AndAlso Request.Cookies("JwtCookie")("JWT") IsNot Nothing Then
            jwtToken = Request.Cookies("JwtCookie")("JWT")
        End If

        Return jwtToken
    End Function

End Class
