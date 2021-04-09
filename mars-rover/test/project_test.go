package test

import (
	"mars-rover/area"
	"mars-rover/commander"
	"mars-rover/rover"
	"testing"
)

func TestRover(t *testing.T)  {
	t.Parallel()
	area.InitArea(5,5)
	expectedX := 1
	expectedY := 3
	expectedDirection := "N"

	r := rover.Setup(1,2,"N")
	if r == nil {
		t.Error("Rover has not been initialised")
	}

	commander.CommandRover(r, "LMLMLMLMM")

	actualX := r.GetX()
	actualY := r.GetY()
	actualDirection := r.GetDirection()

	if actualX != expectedX && actualY != expectedY && actualDirection != expectedDirection{
		 t.Error("Rover position has not matched with expected values")
	}
}

func TestMove(t *testing.T)  {
	t.Parallel()
	area.InitArea(5,5)
	r := rover.Setup(0,0,"W")
	commander.CommandRover(r, "M")
	r.GetPosition()
	if !r.Rip {
		t.Error("Rover gone out of area but it still alive.")
	}
}