package main

import (
	"mars-rover/area"
	"mars-rover/commander"
	"mars-rover/rover"
)

func main()  {

    r1 := rover.Setup(1,2,"N")
	r2 := rover.Setup(3,3,"E")
    area.InitArea(5,5)
	commander.CommandRover(r1, "LMLMLMLMM")
	commander.CommandRover(r2, "MMRMMRMRRM")
	r1.GetPosition()
	r2.GetPosition()
}