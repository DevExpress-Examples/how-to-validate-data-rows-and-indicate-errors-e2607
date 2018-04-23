Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.Xpf.Grid

Namespace ValidatingDataRows
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = TaskList.GetData()

		End Sub

		Private Sub TableView_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.GridRowValidationEventArgs)
			Dim startDate As DateTime = (CType(e.Row, Task)).StartDate
			Dim endDate As DateTime = (CType(e.Row, Task)).EndDate
			e.IsValid = startDate < endDate
		End Sub

		Private Sub TableView_InvalidRowException(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.InvalidRowExceptionEventArgs)
			e.ExceptionMode = ExceptionMode.NoAction
		End Sub
	End Class

	Public Class TaskList
		Public Shared Function GetData() As List(Of Task)
			Dim data As New List(Of Task)()
			data.Add(New Task() With {.TaskName = "Complete Project A", .StartDate = New DateTime(2009, 7, 17), .EndDate = New DateTime(2009, 7, 10)})
			data.Add(New Task() With {.TaskName = "Test Website", .StartDate = New DateTime(2009, 7, 10), .EndDate = New DateTime(2009, 7, 12)})
			data.Add(New Task() With {.TaskName = "Publish Docs", .StartDate = New DateTime(2009, 7, 4), .EndDate = New DateTime(2009, 7, 6)})
			Return data
		End Function
	End Class

	Public Class Task
		Implements IDXDataErrorInfo
		Private privateTaskName As String
		Public Property TaskName() As String
			Get
				Return privateTaskName
			End Get
			Set(ByVal value As String)
				privateTaskName = value
			End Set
		End Property
		Private privateStartDate As DateTime
		Public Property StartDate() As DateTime
			Get
				Return privateStartDate
			End Get
			Set(ByVal value As DateTime)
				privateStartDate = value
			End Set
		End Property
		Private privateEndDate As DateTime
		Public Property EndDate() As DateTime
			Get
				Return privateEndDate
			End Get
			Set(ByVal value As DateTime)
				privateEndDate = value
			End Set
		End Property
		Private Sub GetError(ByVal info As ErrorInfo) Implements IDXDataErrorInfo.GetError
			If StartDate > EndDate Then
				SetErrorInfo(info, "Either StartDate or EndDate should be corrected.", ErrorType.Critical)
			End If
		End Sub
		Private Sub GetPropertyError(ByVal propertyName As String, ByVal info As ErrorInfo) Implements IDXDataErrorInfo.GetPropertyError
			Select Case propertyName
				Case "StartDate"
					If StartDate > EndDate Then
						SetErrorInfo(info, "StartDate must be less than EndDate", ErrorType.Critical)
					End If
				Case "EndDate"
					If StartDate > EndDate Then
						SetErrorInfo(info, "EndDate must be greater than StartDate", ErrorType.Critical)
					End If
				Case "TaskName"
					If IsStringEmpty(TaskName) Then
						SetErrorInfo(info, "Task name hasn't been entered", ErrorType.Information)
					End If
			End Select
		End Sub
		Private Sub SetErrorInfo(ByVal info As ErrorInfo, ByVal errorText As String, ByVal errorType As ErrorType)
			info.ErrorText = errorText
			info.ErrorType = errorType
		End Sub
		Private Function IsStringEmpty(ByVal str As String) As Boolean
			Return (str IsNot Nothing AndAlso str.Trim().Length = 0)
		End Function
	End Class
End Namespace
