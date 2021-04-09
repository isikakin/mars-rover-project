package rover

import (
	"fmt"
)

type Rover struct {
	X         int
	Y         int
	Direction string
	Rip       bool
}

const N string = "N"
const E string = "E"
const S string = "S"
const W string = "W"

func Setup(x,y int, direction string) *Rover {
	var rover = new(Rover)
	rover.X = x
	rover.Y = y
	rover.Direction = direction
	return rover
}

func (rover *Rover) GetX() int {
	return rover.X
}

func (rover *Rover) GetY() int {
	return rover.Y
}

func (rover *Rover) GetDirection() string {
	return rover.Direction
}

func (rover *Rover) GetPosition() {
	fmt.Printf("%v %v %v \n", rover.GetX(), rover.GetY(), rover.GetDirection())
}
