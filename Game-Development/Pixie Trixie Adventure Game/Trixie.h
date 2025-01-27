#pragma once
#include "PlayableCharacter.h"

class Trixie : public PlayableCharacter
{
public:
	// A constructor specific to Trixie
	Trixie();

	// The overriden input handler for Trixie
	bool virtual handleInput();

};


