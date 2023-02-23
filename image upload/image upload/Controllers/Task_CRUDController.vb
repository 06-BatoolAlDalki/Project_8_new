Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports image_upload

Namespace Controllers
    Public Class Task_CRUDController
        Inherits System.Web.Mvc.Controller

        Private db As New MVCEntities

        ' GET: Task_CRUD
        Function Index() As ActionResult
            Return View(db.Task_CRUD.ToList())
        End Function

        ' GET: Task_CRUD/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim task_CRUD As Task_CRUD = db.Task_CRUD.Find(id)
            If IsNothing(task_CRUD) Then
                Return HttpNotFound()
            End If
            Return View(task_CRUD)
        End Function

        ' GET: Task_CRUD/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Task_CRUD/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,farst_Name,Last_Name,Email,Phone,Age,Job_Title,Gender,image,CV")> ByVal task_CRUD As Task_CRUD) As ActionResult
            If ModelState.IsValid Then
                db.Task_CRUD.Add(task_CRUD)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(task_CRUD)
        End Function

        ' GET: Task_CRUD/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim task_CRUD As Task_CRUD = db.Task_CRUD.Find(id)
            If IsNothing(task_CRUD) Then
                Return HttpNotFound()
            End If
            Return View(task_CRUD)
        End Function

        ' POST: Task_CRUD/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,farst_Name,Last_Name,Email,Phone,Age,Job_Title,Gender,image,CV")> ByVal task_CRUD As Task_CRUD) As ActionResult
            If ModelState.IsValid Then
                db.Entry(task_CRUD).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(task_CRUD)
        End Function

        ' GET: Task_CRUD/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim task_CRUD As Task_CRUD = db.Task_CRUD.Find(id)
            If IsNothing(task_CRUD) Then
                Return HttpNotFound()
            End If
            Return View(task_CRUD)
        End Function

        ' POST: Task_CRUD/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim task_CRUD As Task_CRUD = db.Task_CRUD.Find(id)
            db.Task_CRUD.Remove(task_CRUD)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
