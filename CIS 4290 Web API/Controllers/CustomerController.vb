Imports System.Web.Http


Namespace Controllers
    Public Class CustomerController
        Inherits ApiController

        Public Function GetCustomer(CustomerID As Integer) As IHttpActionResult
            Dim customer As CustomerViewModel = Nothing
            Using x = New Customer_DBContext()
                customer = x.Customers _
                  .Where(Function(i) i.CustomerID = CustomerID) _
                  .Select(Function(p) New CustomerViewModel() With {
                        .CustomerID = p.CustomerID,
                        .FirstName = p.FirstName,
                        .LastName = p.LastName,
                        .Email = p.Email,
                        .StreetAddress = p.StreetAddress,
                        .City = p.City,
                        .State = p.State,
                        .PostalCode = p.PostalCode
                    }).FirstOrDefault()
            End Using
            Return Ok(customer)
        End Function


        Public Function PostCustomers(p As CustomerViewModel) As IHttpActionResult
            Try
                If Not ModelState.IsValid Then
                    Return BadRequest("Invalid Data")
                End If

                Using x As New Customer_DBContext()
                    x.Customers.Add(New Customer() With {
                        .CustomerID = p.CustomerID,
                        .FirstName = p.FirstName,
                        .LastName = p.LastName,
                        .Email = p.Email,
                        .StreetAddress = p.StreetAddress,
                        .City = p.City,
                        .State = p.State,
                        .PostalCode = p.PostalCode})

                    x.SaveChanges()
                End Using
            Catch dbEx As System.Data.Entity.Validation.DbEntityValidationException
                Dim raise As Exception = dbEx
                For Each validationErrors In dbEx.EntityValidationErrors
                    For Each validationError In validationErrors.ValidationErrors
                        Dim message As String = String.Format("{0}:{1}",
                    validationErrors.Entry.Entity.ToString(),
                    validationError.ErrorMessage)
                        raise = New InvalidOperationException(message, raise)
                    Next
                Next
                Throw raise
            End Try
            Return Ok(p)
        End Function


        ' Update the existing customer with the new data
        Public Function PutCustomer(CustomerID As Integer, updatedCustomerData As CustomerViewModel) As IHttpActionResult
            Try
                Using x As New Customer_DBContext()
                    Dim existingCustomer = x.Customers.FirstOrDefault(Function(c) c.CustomerID = CustomerID)

                    If existingCustomer IsNot Nothing Then
                        existingCustomer.FirstName = updatedCustomerData.FirstName
                        existingCustomer.LastName = updatedCustomerData.LastName
                        existingCustomer.Email = updatedCustomerData.Email
                        existingCustomer.StreetAddress = updatedCustomerData.StreetAddress
                        existingCustomer.City = updatedCustomerData.City
                        existingCustomer.State = updatedCustomerData.State
                        existingCustomer.PostalCode = updatedCustomerData.PostalCode
                        x.SaveChanges()

                        ' Return the updated customer data
                        Dim updatedCustomerViewModel As New CustomerViewModel() With {
                    .CustomerID = existingCustomer.CustomerID,
                    .FirstName = existingCustomer.FirstName,
                    .LastName = existingCustomer.LastName,
                    .Email = existingCustomer.Email,
                    .StreetAddress = existingCustomer.StreetAddress,
                    .City = existingCustomer.City,
                    .State = existingCustomer.State,
                    .PostalCode = existingCustomer.PostalCode
                }

                        Return Ok(updatedCustomerViewModel)
                    Else
                        Return NotFound()
                    End If
                End Using
            Catch ex As Exception
                Return InternalServerError(ex)
            End Try
        End Function


        Public Function DeleteCustomer(CustomerID As Integer) As IHttpActionResult
            Try
                Using context = New Customer_DBContext()
                    Dim existingCustomer = context.Customers.Find(CustomerID)

                    If existingCustomer Is Nothing Then
                        Return NotFound()
                    End If

                    context.Customers.Remove(existingCustomer)
                    context.SaveChanges()

                    Return Ok($"Customer {CustomerID} has been deleted.")
                End Using
            Catch ex As Exception
                Return InternalServerError(ex)
            End Try
        End Function

    End Class
End Namespace