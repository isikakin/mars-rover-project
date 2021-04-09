package area

type Area struct {
	XMax int
	YMax int
}

type Flag struct {
	X         int
	Y 		  int
	Direction string
}

var FlagArea []Flag

var Planet Area

func InitArea(xMax, yMax int) {
	Planet.XMax = xMax
	Planet.YMax = yMax
}

