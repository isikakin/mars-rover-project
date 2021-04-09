package commander

import (
	"mars-rover/move"
	"mars-rover/rover"
	"strings"
)

func CommandRover(rover *rover.Rover, command string) {
	for _, v := range command {
		switch strings.ToUpper(string(v)) {
		case "M":
			move.Forward(rover)
			break
		case "R":
			move.TurnRight(rover)
			break
		case "L":
			move.TurnLeft(rover)
			break
		}
	}
}
