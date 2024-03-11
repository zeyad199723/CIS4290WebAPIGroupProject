Imports System.Linq
Public Class UserRepository
    Public Function AuthenticateUser(dbContext As Customer_DBContext, loginID As String, transactionKey As String) As User
        Return dbContext.Users.FirstOrDefault(Function(u) u.LoginID = loginID AndAlso u.TransactionKey = transactionKey)
    End Function
End Class
