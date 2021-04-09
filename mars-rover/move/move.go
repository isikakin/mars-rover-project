package move

import (
	"mars-rover/area"
	"mars-rover/rover"
)

var PrevLocation area.Flag

func Forward(r *rover.Rover) {
	control := false
	for _, v := range area.FlagArea{
		control = v.X == r.X && v.Y == r.Y && v.Direction == r.Direction
	}

	if control || r.Rip {
		return
	}

	PrevLocation.X = r.X
	PrevLocation.Y = r.Y
	PrevLocation.Direction = r.Direction

	switch r.GetDirection() {
	case rover.N:
		r.Y += 1
	case rover.S:
		r.Y -= 1
	case rover.E:
		r.X += 1
	case rover.W:
		r.X -= 1
	}

	if r.X < 0 || r.X > area.Planet.XMax || r.Y < 0 || r.Y > area.Planet.YMax{
		area.FlagArea = append(area.FlagArea, PrevLocation)
		r.Rip = true
		//log.Fatal("Rover Position can not be bigger than max positions!");
	}
}

func TurnRight(r *rover.Rover) {
	switch r.Direction {
	case rover.N:
		r.Direction = rover.E
		break
	case rover.E:
		r.Direction = rover.S
		break
	case rover.S:
		r.Direction = rover.W
		break
	case rover.W:
		r.Direction = rover.N
		break
	}
}

func TurnLeft(r *rover.Rover) {
	TurnRight(r)
	TurnRight(r)
	TurnRight(r)
}
