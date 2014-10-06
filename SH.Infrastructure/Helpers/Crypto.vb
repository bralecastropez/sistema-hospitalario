Imports System
Imports System.Text
Imports System.Security.Cryptography

Namespace SH.Infrastructure.Helpers
    Public Class Crypto
        Public Shared Function Verify(ByVal plainText As String, ByVal hashCode As Byte()) As Boolean

            Dim md5Hash As MD5 = MD5.Create()

            Dim hash As String = GetMd5Hash(md5Hash, plainText)

            If VerifyMd5Hash(md5Hash, hashCode, hash) Then
                Return True
            End If

            Return False
        End Function

        Overloads Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

            ' Convert the input string to a byte array and compute the hash. 
            Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

            ' Create a new Stringbuilder to collect the bytes 
            ' and create a string. 
            Dim sBuilder As New StringBuilder()

            ' Loop through each byte of the hashed data  
            ' and format each one as a hexadecimal string. 
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i

            ' Return the hexadecimal string. 
            Return sBuilder.ToString()

        End Function 'GetMd5Hash
        Overloads Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As Byte()) As String
            Dim sBuilder As New StringBuilder()

            ' Loop through each byte of the hashed data  
            ' and format each one as a hexadecimal string. 
            Dim i As Integer
            For i = 0 To input.Length - 1
                sBuilder.Append(input(i).ToString("x2"))
            Next i

            ' Return the hexadecimal string. 
            Return sBuilder.ToString()
        End Function

        Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As Byte(), ByVal hash As String) As Boolean
            ' Hash the input. 
            Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

            ' Create a StringComparer an compare the hashes. 
            Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

            If 0 = comparer.Compare(hashOfInput, hash) Then
                Return True
            Else
                Return False
            End If

        End Function 'VerifyMd5Hash
    End Class
End Namespace

