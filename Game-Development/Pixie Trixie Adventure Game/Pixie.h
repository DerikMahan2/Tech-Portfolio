#pragma once
#include "PlayableCharacter.h"

class Pixie : public PlayableCharacter
{
public:
	// A constructor specific to Pixie
	Pixie();

	// The overriden input handler for Pixie
	bool virtual handleInput();

};

