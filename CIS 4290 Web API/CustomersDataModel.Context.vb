﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class Customer_DBContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=Customer_DBContext")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Users() As DbSet(Of User)
    Public Overridable Property Customers() As DbSet(Of Customer)
    Public Overridable Property CreditCardInfoes() As DbSet(Of CreditCardInfo)

End Class
