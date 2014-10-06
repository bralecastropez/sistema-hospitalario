Imports SH.BusinessObjects.Models
Imports System.Data.Metadata.Edm
Imports System.Reflection
Imports System.IO
Imports System.Xml
Imports System.Data.Mapping

Public Class DataContext

    Private Shared _DBEntities As dbHospitalEntities

    Public Shared Property DBEntities() As dbHospitalEntities
        Get
            If _DBEntities Is Nothing Then
                _DBEntities = New dbHospitalEntities()
            End If
            Return _DBEntities
        End Get
        Set(value As dbHospitalEntities)
            _DBEntities = value
        End Set
    End Property

End Class
