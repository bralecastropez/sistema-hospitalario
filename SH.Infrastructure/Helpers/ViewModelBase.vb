﻿Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Input

Namespace SH.Infrastructure.Helpers
    Public Class ViewModelBase
        Implements INotifyPropertyChanged

        Private myServiceLocator As New ServiceLocator

        Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

        Protected Sub OnPropertyChanged(ByVal strPropertyName As String)
            If Me.PropertyChangedEvent IsNot Nothing Then
                RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(strPropertyName))
            End If
        End Sub

        Private privateThrowOnInvalidPropertyName As Boolean

        Protected Overridable Property ThrowOnInvalidPropertyName() As Boolean
            Get
                Return privateThrowOnInvalidPropertyName
            End Get
            Set(ByVal value As Boolean)
                privateThrowOnInvalidPropertyName = value
            End Set
        End Property

        <Conditional("DEBUG"), DebuggerStepThrough()> _
        Public Sub VerifyPropertyName(ByVal propertyName As String)
            ' Verify that the property name matches a real,
            ' public, instance property on this object.
            If TypeDescriptor.GetProperties(Me)(propertyName) Is Nothing Then
                Dim msg As String = "Invalid property name: " & propertyName

                If Me.ThrowOnInvalidPropertyName Then
                    Throw New Exception(msg)
                Else
                    Debug.Fail(msg)
                End If
            End If
        End Sub

        Private privateDisplayName As String

        Public Overridable Property DisplayName() As String
            Get
                Return privateDisplayName
            End Get

            Protected Set(ByVal value As String)
                privateDisplayName = value
            End Set
        End Property

        Public Function ServiceLocator() As ServiceLocator
            Return Me.myServiceLocator
        End Function

        Public Function GetService(Of T)() As T
            Return myServiceLocator.GetService(Of T)()
        End Function
    End Class
End Namespace
