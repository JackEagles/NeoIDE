Imports System.Reflection

Public Module ColorExtensions
    Public Function GetNearestName(ByVal unknownColor As Color) As String
        If unknownColor.IsNamedColor Then
            Return unknownColor.Name
        End If

        Dim oBestMatch As ColorName = GetNearestNameInternal(unknownColor)

        Return oBestMatch.Name
    End Function
    Public Function GetNearestKnownColor(ByVal unknownColor As Color) As KnownColor
        If unknownColor.IsKnownColor Then
            Return unknownColor.ToKnownColor
        End If

        Dim oBestMatch As ColorName = GetNearestKnownColorInternal(unknownColor)

        Return oBestMatch.Color.ToKnownColor
    End Function

    Friend Structure ColorName
        Public Name As String
        Public Color As Color
        Public Distance As Double
        Public Function ToRGBString() As String
            Return String.Format("RGB=({0},{1},{2})", Color.R, Color.G, Color.B)
        End Function
    End Structure

    Friend Function GetNearestNameInternal(ByVal unknownColor As Color) As ColorName
        Dim oBestMatch As ColorName = Nothing
        Dim nClosestDistance As Double = Double.MaxValue
        Dim oBindingFlags As BindingFlags = BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.Static
        For Each oProperty As PropertyInfo In GetType(Color).GetProperties(oBindingFlags)
            Dim oNamedColor As Color = DirectCast(oProperty.GetValue(Nothing, Nothing), Color)
            Dim nDistance As Double
            nDistance = Math.Sqrt((CInt(unknownColor.R) - oNamedColor.R) ^ 2 + (CInt(unknownColor.G) - oNamedColor.G) ^ 2 + (CInt(unknownColor.B) - oNamedColor.B) ^ 2)
            nDistance = Math.Sqrt(nDistance / 3)
            If nDistance < nClosestDistance Then
                nClosestDistance = nDistance
                oBestMatch.Name = oProperty.Name
                oBestMatch.Distance = nDistance
                oBestMatch.Color = oNamedColor
            End If
        Next
        Return oBestMatch
    End Function

    Friend Function GetNearestKnownColorInternal(ByVal unknownColor As Color) As ColorName
        Dim oBestMatch As ColorName = Nothing
        Dim nClosestDistance As Double = Double.MaxValue
        For Each sColorName As String In [Enum].GetNames(GetType(KnownColor))
            Dim oNamedColor As Color = Color.FromName(sColorName)
            Dim nDistance As Double
            nDistance = Math.Sqrt((CInt(unknownColor.R) - oNamedColor.R) ^ 2 + (CInt(unknownColor.G) - oNamedColor.G) ^ 2 + (CInt(unknownColor.B) - oNamedColor.B) ^ 2)
            nDistance = Math.Sqrt(nDistance / 3)
            If nDistance < nClosestDistance Then
                nClosestDistance = nDistance
                oBestMatch.Name = oNamedColor.Name
                oBestMatch.Distance = nDistance
                oBestMatch.Color = oNamedColor
            End If
        Next
        Return oBestMatch
    End Function

End Module
