Imports CarLibrary

Module Module1

    Public Class SuperCar
        Inherits SportsCar
        Public Overrides Sub TurboBoost()

            Console.WriteLine($"in SuperCar, {PetName}, {MaxSpeed}, {CurrentSpeed}")

        End Sub


    End Class

    Sub Main()
        Dim sc As New SuperCar With {
            .PetName = "ZL",
            .CurrentSpeed = 15,
            .MaxSpeed = 100
        }

        sc.TurboBoost()

        Console.ReadLine()
    End Sub

End Module
