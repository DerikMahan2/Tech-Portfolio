#include "SoundManager.h"
#include <SFML/Audio.hpp>

using namespace sf;

SoundManager::SoundManager()
{
	// Load the sound in to the buffers
	m_FireBuffer.loadFromFile("sound/fire1.wav");
	m_FallInFireBuffer.loadFromFile("sound/fallinfire.wav");
	m_FallInWaterBuffer.loadFromFile("sound/fallinwater.wav");
	m_JumpBuffer.loadFromFile("sound/jump.wav");
	m_ReachGoalBuffer.loadFromFile("sound/reachgoal.wav");

	// Associate sounds with buffers
	m_Fire1Sound.setBuffer(m_FallInFireBuffer);
	m_Fire2Sound.setBuffer(m_FallInFireBuffer);
	m_Fire3Sound.setBuffer(m_FallInFireBuffer);
	m_FallInFireSound.setBuffer(m_FallInFireBuffer);
	m_FallInWaterSound.setBuffer(m_FallInWaterBuffer);
	m_JumpSound.setBuffer(m_JumpBuffer);
	m_ReachGoalSound.setBuffer(m_ReachGoalBuffer);

	// When player is close sound is full volume
	float minDistance = 150;
	// The sound reduces as the player moves away
	float attenuation = 15;

	// Setting attenuation levels
	m_Fire1Sound.setAttenuation(attenuation);
	m_Fire2Sound.setAttenuation(attenuation);
	m_Fire3Sound.setAttenuation(attenuation);

	// Setting min distance
	m_Fire1Sound.setMinDistance(minDistance);
	m_Fire2Sound.setMinDistance(minDistance);
	m_Fire3Sound.setMinDistance(minDistance);

	// Loop for all the fire sounds when played
	m_Fire1Sound.setLoop(true);
	m_Fire2Sound.setLoop(true);
	m_Fire3Sound.setLoop(true);
}

void SoundManager::playFire(
	Vector2f emitterLocation, Vector2f listenerLocation)
{
	// Who is the listener? Pixie
	Listener::setPosition(listenerLocation.x,
		listenerLocation.y, 0.0f);

	switch (m_NextSound)
	{
	case 1:
		// locate and move the source
		m_Fire1Sound.setPosition(emitterLocation.x,
			emitterLocation.y, 0.0f);

		if (m_Fire1Sound.getStatus() == Sound::Status::Stopped)
		{
			// Play the sound if not already
			m_Fire1Sound.play();
		}
		break;

	case 2:
		// Same as the first sound but for 2
		m_Fire2Sound.setPosition(emitterLocation.x,
			emitterLocation.y, 0.0f);

		if (m_Fire2Sound.getStatus() == Sound::Status::Stopped)
		{
			// Play the sound if not already
			m_Fire2Sound.play();
		}
		break;

	case 3:
		// Again for the 3rd
		m_Fire3Sound.setPosition(emitterLocation.x,
			emitterLocation.y, 0.0f);

		if (m_Fire3Sound.getStatus() == Sound::Status::Stopped)
		{
			// Play the sound if not already
			m_Fire3Sound.play();
		}
		break;
	}

	// Increment to the next sound
	m_NextSound++;

	// Loop back to	1 after the 3rd has played
	if (m_NextSound > 3)
	{
		m_NextSound = 1;
	}
}

void SoundManager::playFallInFire()
{
	m_FallInFireSound.setRelativeToListener(true);
	m_FallInFireSound.play();
}

void SoundManager::playFallInWater()
{
	m_FallInWaterSound.setRelativeToListener(true);
	m_FallInWaterSound.play();
}

void SoundManager::playJump()
{
	m_JumpSound.setRelativeToListener(true);
	m_JumpSound.play();
}

void SoundManager::playReachGoal()
{
	m_ReachGoalSound.setRelativeToListener(true);
	m_ReachGoalSound.play();
}
