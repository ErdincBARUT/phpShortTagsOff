Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Public Class Form1

    Public Function replaceTags(ByRef data As String) As String

        data = Replace(data, "<?//", "<?php //")
        data = Replace(data, "<?=", "<?php echo ")
        data = Replace(data, "<?", "<?php")
        data = Replace(data, "<?phpphp", "<?php")
        data = Replace(data, "<?php}", "<?php }")

        Return data

    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fil As String
        ListBox1.Items.Clear()



        For Each fil In Directory.EnumerateFiles(Application.StartupPath, "*.php", SearchOption.AllDirectories)

            ListBox1.Items.Add(fil)
        Next



    End Sub
    Public Sub processFile(path As String)
        Dim content As String() = System.IO.File.ReadAllLines(path)
        Dim i As Integer
        Dim dump As New StringBuilder
        For i = 0 To UBound(content)
            content(i) = replaceTags(content(i))
            dump.AppendLine(content(i))
        Next i


        Using outputFile As New StreamWriter(path)
            outputFile.Write(dump)
        End Using
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox2.Items.Clear()
        Dim i As Integer
        For i = 0 To ListBox1.Items.Count - 1
            processFile(ListBox1.Items(i))
            ListBox2.Items.Add(ListBox1.Items(i))
        Next


    End Sub
End Class
