﻿Imports MySql.Data.MySqlClient

Public Class frmPBSubKriteria
    Dim c As New clsConn
    Dim namaKriteria() As String
    Dim idKriteria() As String

    Dim namaSubKriteria() As String
    Dim idSubKriteria() As String

    Dim jlhBulat As Integer = 2

    Private Sub kosongkan()
        Call dgvPB.Rows.Clear()
        Call dgvPB.Columns.Clear()

        Call dgvPrioritas.Rows.Clear()
        Call dgvPrioritas.Columns.Clear()

        Call dgvPenjumlahan.Rows.Clear()
        Call dgvPenjumlahan.Columns.Clear()

        Call dgvRasio.Rows.Clear()
        Call dgvRasio.Columns.Clear()

        Call dgvHasil.Rows.Clear()
        Call dgvHasil.Columns.Clear()
    End Sub

    Private Sub loadData()
        Call kosongkan()
        If cmbKriteria.Text = "--Pilih--" Then
            Call kosongkan()
        Else
            namaSubKriteria = c.getList("subkriteria", "nama_subkriteria", "id_kriteria", idKriteria(Array.IndexOf(namaKriteria, cmbKriteria.Text.ToString)), "urutan")
            idSubKriteria = c.getList("subkriteria", "id_subkriteria", "id_kriteria", idKriteria(Array.IndexOf(namaKriteria, cmbKriteria.Text.ToString)), "urutan")

            If namaSubKriteria.Any = False Then
                Call kosongkan()
            Else
                Call setheader()
                Call bersihkan()
                Call setColorForEditAbleCell()
                Call loadRecord()
                Call proses()
            End If
        End If
    End Sub

    Private Sub setheader()
        dgvPB.Columns.Clear()
        For Each item As Object In namaSubKriteria
            dgvPB.Columns.Add(item, item)
            dgvPrioritas.Columns.Add(item, item)
            dgvPenjumlahan.Columns.Add(item, item)
        Next
        dgvPB.Rows.Add(namaSubKriteria.Length)
        dgvPrioritas.Rows.Add(namaSubKriteria.Length)
        dgvPenjumlahan.Rows.Add(namaSubKriteria.Length)

        dgvRasio.Columns.Add("", "Jumlah per baris")
        dgvRasio.Columns.Add("", "Prioritas")
        dgvRasio.Columns.Add("", "Hasil")

        dgvRasio.Rows.Add(namaSubKriteria.Length)
        For i As Integer = 0 To (namaSubKriteria.Length - 1)
            dgvPB.Rows(i).HeaderCell.Value = namaSubKriteria(i)
            dgvPrioritas.Rows(i).HeaderCell.Value = namaSubKriteria(i)
            dgvPenjumlahan.Rows(i).HeaderCell.Value = namaSubKriteria(i)
            dgvRasio.Rows(i).HeaderCell.Value = namaSubKriteria(i)
        Next

        For Each col As DataGridViewColumn In dgvPB.Columns
            col.SortMode = DataGridViewColumnSortMode.Programmatic
        Next
        For Each col As DataGridViewColumn In dgvPrioritas.Columns
            col.SortMode = DataGridViewColumnSortMode.Programmatic
        Next
        For Each col As DataGridViewColumn In dgvPenjumlahan.Columns
            col.SortMode = DataGridViewColumnSortMode.Programmatic
        Next
        For Each col As DataGridViewColumn In dgvRasio.Columns
            col.SortMode = DataGridViewColumnSortMode.Programmatic
        Next
        For Each col As DataGridViewColumn In dgvHasil.Columns
            col.SortMode = DataGridViewColumnSortMode.Programmatic
        Next

        dgvPB.Rows(namaSubKriteria.Length).HeaderCell.Value = "Jumlah"
        dgvPrioritas.Rows(namaSubKriteria.Length).HeaderCell.Value = "Jumlah"
        dgvPenjumlahan.Columns.Add("", "Jumlah")
        dgvRasio.Rows(namaSubKriteria.Length).HeaderCell.Value = "Jumlah"

        dgvPrioritas.Columns.Add("", "Jumlah per baris")
        dgvPrioritas.Columns.Add("", "Prioritas")
        dgvPrioritas.Columns.Add("", "Prioritas Subkriteria")

        dgvHasil.Columns.Add("", "Hasil")
        dgvHasil.Rows.Add(4)
        dgvHasil.Rows(0).HeaderCell.Value = "λ maks"
        dgvHasil.Rows(1).HeaderCell.Value = "Index Konsistensi"
        dgvHasil.Rows(2).HeaderCell.Value = "Rasio Konsistensi"
        dgvHasil.Rows(3).HeaderCell.Value = "Konsistensi"
    End Sub

    Private Sub loadRecord()
        Dim sqlcmd As MySqlCommand
        Dim sqlrd As MySqlDataReader

        Try
            Call c.myOpen()
            sqlcmd = New MySqlCommand("SELECT * FROM pb WHERE kriteria='" & idKriteria(Array.IndexOf(namaKriteria, cmbKriteria.Text.ToString)) & "'", c.conn)
            sqlrd = sqlcmd.ExecuteReader
            If sqlrd.HasRows = True Then
                While sqlrd.Read = True
                    dgvPB.Item(Array.IndexOf(idSubKriteria, sqlrd("colindex").ToString), Array.IndexOf(idSubKriteria, sqlrd("rowindex").ToString)).Value = Val(Format(sqlrd("nilai"), "0.00"))
                End While
                c.myClose()
            Else
                c.myClose()
                Call bersihkan()
            End If
        Catch ex As Exception
            MsgBox("[ERROR:SPB1] " & ex.Message, vbCritical + vbOKOnly, c.namaProgram)
        Finally
            c.myClose()
        End Try
    End Sub

    Private Sub setColorForEditAbleCell()
        For i = 0 To namaSubKriteria.Length - 1
            For j = 0 To namaSubKriteria.Length - 1
                If i < j Then
                    dgvPB.Rows(i).Cells(j).Style.BackColor = Color.Gray
                End If
            Next
        Next
    End Sub

    Private Sub bersihkan()
        For i = 0 To namaSubKriteria.Length - 1
            For j = 0 To namaSubKriteria.Length - 1
                dgvPB.Item(j, i).Value = 1
            Next
        Next

        For i = 0 To namaSubKriteria.Length - 1
            dgvPB.Item(i, i).Value = 1
        Next
    End Sub

    'Buat Matrik
    Private Sub hitungPB()
        For i = 0 To namaSubKriteria.Length - 1
            For j = 0 To namaSubKriteria.Length - 1
                If i > j Then
                    dgvPB.Item(j, i).Value = Format(Math.Round(1 / Val(dgvPB.Item(i, j).Value), jlhBulat), "0.00")
                End If
            Next
        Next

        For i = 0 To namaSubKriteria.Length - 1
            Dim jumlah As Double = 0
            For j = 0 To namaSubKriteria.Length - 1
                jumlah += Val(dgvPB.Item(i, j).Value)
            Next
            dgvPB.Item(i, namaSubKriteria.Length).Value = Format(Math.Round(jumlah, jlhBulat), "0.00")
        Next
    End Sub

    Private Sub hitungMatriksPrioritas()
        'menyamakan penyebut
        For i = 0 To namaSubKriteria.Length - 1
            For j = 0 To namaSubKriteria.Length - 1
                dgvPrioritas.Item(i, j).Value = Format(Math.Round(Val(dgvPB.Item(i, j).Value) / Val(dgvPB.Item(i, namaSubKriteria.Length).Value), jlhBulat), "0.00")
            Next
        Next

        'Penyebut
        For i = 0 To namaSubKriteria.Length - 1
            Dim jumlah As Double = 0
            For j = 0 To namaSubKriteria.Length - 1
                jumlah += dgvPrioritas.Item(i, j).Value
            Next
            dgvPrioritas.Item(i, namaSubKriteria.Length).Value = Format(Math.Round(jumlah, jlhBulat), "0.00")
        Next

        For i = 0 To namaSubKriteria.Length - 1
            Dim jumlah As Double = 0
            For j = 0 To namaSubKriteria.Length - 1
                jumlah += Val(dgvPrioritas.Item(j, i).Value)
            Next
            dgvPrioritas.Item(namaSubKriteria.Length, i).Value = Format(Math.Round(jumlah, jlhBulat), "0.00")
        Next

        Dim getMax As Double = 0
        For i = 0 To namaSubKriteria.Length - 1
            dgvPrioritas.Item(namaSubKriteria.Length + 1, i).Value = Format(Math.Round(Val(dgvPrioritas.Item(namaSubKriteria.Length, i).Value) / namaSubKriteria.Length, jlhBulat), "0.00")
            If Val(getMax) < Val(dgvPrioritas.Item(namaSubKriteria.Length + 1, i).Value) Then
                getMax = Format(Math.Round(Val(dgvPrioritas.Item(namaSubKriteria.Length + 1, i).Value), jlhBulat), "0.00")
            End If
        Next

        For i = 0 To namaSubKriteria.Length - 1
            dgvPrioritas.Item(namaSubKriteria.Length + 2, i).Value = Format(Math.Round(Val(dgvPrioritas.Item(namaSubKriteria.Length + 1, i).Value / getMax), jlhBulat), "0.00")
        Next
    End Sub

    Private Sub hitungJumlahPerbaris()
        For i = 0 To namaSubKriteria.Length - 1
            Dim jumlah As Double = 0
            For j = 0 To namaSubKriteria.Length - 1
                dgvPenjumlahan.Item(j, i).Value = Format(Math.Round(Val(dgvPrioritas.Item(namaSubKriteria.Length + 1, j).Value) * Val(dgvPB.Item(j, i).Value), jlhBulat), "0.00")
                jumlah += Val(dgvPenjumlahan.Item(j, i).Value)
            Next
            dgvPenjumlahan.Item(namaSubKriteria.Length, i).Value = Format(Math.Round(jumlah, jlhBulat), "0.00")
        Next
    End Sub

    Private Sub hitungRasio()
        For i = 0 To namaSubKriteria.Length - 1
            dgvRasio.Item(0, i).Value = Val(dgvPenjumlahan.Item(namaSubKriteria.Length, i).Value)
        Next

        For i = 0 To namaSubKriteria.Length - 1
            dgvRasio.Item(1, i).Value = Val(dgvPrioritas.Item(namaSubKriteria.Length + 1, i).Value)
        Next

        For i = 0 To namaSubKriteria.Length - 1
            Dim jumlah As Double = 0
            For j = 0 To 1
                jumlah += Val(dgvRasio.Item(j, i).Value)
            Next
            dgvRasio.Item(2, i).Value = Format(Math.Round(jumlah, jlhBulat), "0.00")
        Next

        Dim ajumlah As Double = 0
        For i = 0 To namaSubKriteria.Length - 1
            ajumlah += Val(dgvRasio.Item(2, i).Value)
        Next
        dgvRasio.Item(2, namaSubKriteria.Length).Value = Format(Math.Round(ajumlah, jlhBulat), "0.00")
    End Sub

    Private Sub hitungHasil()
        dgvHasil.Item(0, 0).Value = Format(Math.Round(Val(namaSubKriteria.Length) / Val(dgvRasio.Item(2, namaSubKriteria.Length).Value), jlhBulat), "0.00")

        dgvHasil.Item(0, 1).Value = Format(Math.Round(Val(dgvHasil.Item(0, 0).Value) - Val(namaSubKriteria.Length), jlhBulat), "0.00")
        dgvHasil.Item(0, 1).Value = Format(Math.Round(Val(dgvHasil.Item(0, 1).Value) / Val(namaSubKriteria.Length), jlhBulat), "0.00")

        dgvHasil.Item(0, 2).Value = Format(Math.Round(Val(dgvHasil.Item(0, 1).Value) / Val(NilaiIndeksRandom(namaSubKriteria.Length)), jlhBulat), "0.00")

        If Val(dgvHasil.Item(0, 2).Value) < 0.1 Then
            dgvHasil.Item(0, 3).Value = "Konsisten"
        Else
            dgvHasil.Item(0, 3).Value = "Tidak Konsisten"
        End If
    End Sub

    Private Sub proses()
        Call hitungPB()
        Call hitungMatriksPrioritas()
        Call hitungJumlahPerbaris()
        Call hitungRasio()
        Call hitungHasil()
    End Sub

    Private Sub frmPBSubKriteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        namaKriteria = c.getList("kriteria", "nama_kriteria", "urutan")
        cmbKriteria.Items.Clear()
        If namaKriteria.Any = True Then
            For Each item As Object In namaKriteria
                cmbKriteria.Items.Add(item)
            Next
            cmbKriteria.Text = "--Pilih--"
            idKriteria = c.getList("kriteria", "id_kriteria", "urutan")
            Call loadData()
        Else
            MsgBox("Kriteria tidak ditemukan", vbInformation + vbOKOnly, c.namaProgram)
        End If
    End Sub


    Private Sub dgvPB_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPB.CellBeginEdit
        If e.ColumnIndex > e.RowIndex Then
            If e.ColumnIndex >= 0 Then
                If e.RowIndex >= 0 Then
                    Dim cmbSaaty As New DataGridViewComboBoxCell
                    cmbSaaty.Items.Clear()
                    cmbSaaty.Items.Add("0.11")
                    cmbSaaty.Items.Add("0.12")
                    cmbSaaty.Items.Add("0.14")
                    cmbSaaty.Items.Add("0.16")
                    cmbSaaty.Items.Add("0.20")
                    cmbSaaty.Items.Add("0.25")
                    cmbSaaty.Items.Add("0.33")
                    cmbSaaty.Items.Add("0.50")
                    cmbSaaty.Items.Add("2.00")
                    cmbSaaty.Items.Add("3.00")
                    cmbSaaty.Items.Add("4.00")
                    cmbSaaty.Items.Add("5.00")
                    cmbSaaty.Items.Add("6.00")
                    cmbSaaty.Items.Add("7.00")
                    cmbSaaty.Items.Add("8.00")
                    cmbSaaty.Items.Add("9.00")
                    dgvPB.Item(e.ColumnIndex, e.RowIndex) = cmbSaaty
                End If
            End If
        Else
            e.Cancel = True
        End If
    End Sub


    Private Sub cmdProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProses.Click
        If dgvPB.ColumnCount > 0 Then
            Call proses()
        End If
    End Sub

    Private Sub cmdTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTutup.Click
        Me.Hide()
    End Sub

    Private Sub cmbKriteria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKriteria.SelectedIndexChanged
        Call loadData()
    End Sub

    Private Sub dgvPrioritas_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrioritas.CellBeginEdit
        e.Cancel = True
    End Sub

    Private Sub dgvPenjumlahan_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPenjumlahan.CellBeginEdit
        e.Cancel = True
    End Sub

    Private Sub dgvRasio_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRasio.CellBeginEdit
        e.Cancel = True
    End Sub

    Private Sub dgvHasil_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvHasil.CellBeginEdit
        e.Cancel = True
    End Sub

    Private Sub cmdSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSimpan.Click
        If dgvPB.ColumnCount > 0 Then
            Call proses()

            'update pb
            If c.deleteData("pb", "kriteria", idKriteria(Array.IndexOf(namaKriteria, cmbKriteria.Text.ToString))) = True Then
                'nothing
            End If
            For i = 0 To namaSubKriteria.Length - 1
                For j = 0 To namaSubKriteria.Length - 1
                    Dim fields() As String = {"kriteria", "colindex", "rowindex", "nilai"}
                    Dim datas() As String = {idKriteria(Array.IndexOf(namaKriteria, cmbKriteria.Text.ToString)), idSubKriteria(Array.IndexOf(namaSubKriteria, dgvPB.Columns(i).HeaderText.ToString)), idSubKriteria(Array.IndexOf(namaSubKriteria, dgvPB.Rows(j).HeaderCell.Value.ToString)), dgvPB.Item(i, j).Value.ToString}
                    If c.insertData("pb", fields, datas) Then
                        'nothing
                    End If
                Next
            Next

            'update nilai
            If c.deleteData("hasil", "id_kriteria", idKriteria(Array.IndexOf(namaKriteria, cmbKriteria.Text.ToString))) = True Then
                'nothing
            End If
            For i = 0 To namaSubKriteria.Length - 1
                Dim fields() As String = {"id_kriteria", "id_subkriteria", "hasil"}
                Dim datas() As String = {idKriteria(Array.IndexOf(namaKriteria, cmbKriteria.Text.ToString)), idSubKriteria(Array.IndexOf(namaSubKriteria, dgvRasio.Rows(i).HeaderCell.Value.ToString)), dgvPrioritas.Item(namaSubKriteria.Length + 2, i).Value.ToString}
                If c.insertData("hasil", fields, datas) Then
                    'nothing
                End If
            Next
            MsgBox("Tersimpan", vbInformation + vbOKOnly, c.namaProgram)
        End If
    End Sub
End Class