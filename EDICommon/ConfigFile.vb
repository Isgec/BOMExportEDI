﻿Imports System.Xml
Imports System.Xml.Serialization
<Serializable>
Public Class ConfigFile
  Implements ICloneable
  Public Function Clone() As Object Implements ICloneable.Clone
    Return MyBase.MemberwiseClone()
  End Function

  Public Property VaultUserName As String = ""
  Public Property VaultUserPassword As String = ""
  Public Property VaultServer As String = ""
  Public Property VaultDatabase As String = ""
  Public Property TempFolderPath As String = ""
  Public Property PDFFolderPath As String = ""
  Public Property XMLFolderPath As String = ""
  Public Property TitleBlockNames As String = ""
  Public Property BAANBlockNames As String = ""
  Public Property PartItemBlockNames As String = ""
  Public Property ReferenceDrawingBlockNames As String = ""
  Public Property JobPath As String = ""
  Public Property CreatePDFFiles As String = ""
  Public Property AutoCADVisible As Boolean = False
  'Derived Property
  Public Property StartupPath As String = ""
  Public Property JobPathError As String = ""
  Public Property JobPathProcessed As String = ""
  Public Property JobPathWorking As String = ""
  Public Property SerializedAt As String = ""
  Public Shared Function GetFile(ByVal FilePath As String) As ConfigFile
    Dim tmp As ConfigFile = Nothing
    If IO.File.Exists(FilePath) Then
      Dim rd As XmlReader = Nothing
      Try
        tmp = New ConfigFile
        rd = XmlReader.Create(FilePath)
        While rd.Read
          If rd.NodeType = XmlNodeType.Element Then

            Select Case rd.Name
              Case "VaultUserName"
                rd.Read()
                tmp.VaultUserName = rd.Value.Trim
              Case "VaultUserPassword"
                rd.Read()
                tmp.VaultUserPassword = rd.Value.Trim
              Case "VaultServer"
                rd.Read()
                tmp.VaultServer = rd.Value.Trim
              Case "VaultDatabase"
                rd.Read()
                tmp.VaultDatabase = rd.Value.Trim
              Case "TempFolderPath"
                rd.Read()
                tmp.TempFolderPath = rd.Value.Trim
              Case "PDFFolderPath"
                rd.Read()
                tmp.PDFFolderPath = rd.Value.Trim
              Case "XMLFolderPath"
                rd.Read()
                tmp.XMLFolderPath = rd.Value.Trim
              Case "TitleBlockNames"
                rd.Read()
                tmp.TitleBlockNames = rd.Value.Trim
              Case "BAANBlockNames"
                rd.Read()
                tmp.BAANBlockNames = rd.Value.Trim
              Case "PartItemBlockNames"
                rd.Read()
                tmp.PartItemBlockNames = rd.Value.Trim
              Case "ReferenceDrawingBlockNames"
                rd.Read()
                tmp.ReferenceDrawingBlockNames = rd.Value.Trim
              Case "AutoCADVisible"
                Try
                  rd.Read()
                  tmp.AutoCADVisible = Convert.ToBoolean(rd.Value.Trim)
                Catch ex As Exception
                End Try
              Case "JobFilePath"
                rd.Read()
                tmp.JobPath = rd.Value.Trim
                tmp.JobPathError = tmp.JobPath & "\Error"
                tmp.JobPathProcessed = tmp.JobPath & "\Processed"
                tmp.JobPathWorking = tmp.JobPath & "\Working"
              Case "CreatePDFFiles"
                Try
                  rd.Read()
                  tmp.CreatePDFFiles = Convert.ToBoolean(rd.Value.Trim)
                Catch ex As Exception
                End Try
            End Select
          End If
        End While
        rd.Close()
      Catch ex As Exception
      End Try
    End If
    Return tmp
  End Function
  Public Shared Function Serialize(ByVal jpConfig As ConfigFile, ByVal SerializeAt As String) As ConfigFile
    jpConfig.SerializedAt = SerializeAt
    Dim oSrz As XmlSerializer = New XmlSerializer(jpConfig.GetType)
    Dim oSW As IO.StreamWriter = New IO.StreamWriter(SerializeAt)
    oSrz.Serialize(oSW, jpConfig)
    oSW.Close()
    Return jpConfig
  End Function
  Public Shared Function DeSerialize(Optional ByVal jpConfig As ConfigFile = Nothing, Optional ByVal SerializedAt As String = "") As ConfigFile
    Dim FileName As String = ""
    If jpConfig IsNot Nothing Then
      FileName = jpConfig.SerializedAt
    Else
      FileName = SerializedAt
    End If
    If IO.File.Exists(FileName) Then
      jpConfig = New ConfigFile
      Dim oFS As IO.FileStream = New IO.FileStream(FileName, IO.FileMode.Open)
      Dim oSrz As XmlSerializer = New XmlSerializer(jpConfig.GetType)
      jpConfig = CType(oSrz.Deserialize(oFS), ConfigFile)
      oFS.Close()
    End If
    Return jpConfig
  End Function

End Class
