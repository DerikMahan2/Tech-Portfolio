#include "Engine.h"
#include <SFML/Graphics.hpp>
#include <sstream>

using namespace sf;

void Engine::update(float dtAsSeconds)
{
	if (m_NewLevelRequired)
	{
		// Load a level
		loadLevel();
	}

	if (m_Playing)
	{
		// Update Pixie
		m_Pixie.update(dtAsSeconds);

		// Update Trixie
		m_Trixie.update(dtAsSeconds);

		// Detect collision and if the player reached goal,
		// second part is only if Pixie reached goal.
		if (detectCollisions(m_Pixie) && detectCollisions(m_Trixie))
		{
			// New level required
			m_NewLevelRequired = true;

			// Play sound for goal
			m_SM.playReachGoal();

		}
		else
		{
			// Trixie's collision detection
			detectCollisions(m_Trixie);
		}

		// Let the two jump on each other
		if (m_Trixie.getFeet().intersects(m_Pixie.getHead()))
		{
			m_Trixie.stopFalling(m_Pixie.getHead().top);
		}
		else if (m_Pixie.getFeet().intersects(m_Trixie.getHead()))
		{
			m_Pixie.stopFalling(m_Trixie.getHead().top);
		}

		// Count down the time the player has left
		m_TimeRemaining -= dtAsSeconds;

		// Have Pixie and Trixie run out of time?
		if (m_TimeRemaining <= 0)
		{
			m_NewLevelRequired = true;
		}

	}// End if playing

	// Check if fire sound needed
	vector<Vector2f>::iterator it;
	// Iterate through the vector
	for (it = m_FireEmitters.begin(); it != m_FireEmitters.end(); it++)
	{
		// Find and store emitter 
		float posX = (*it).x;
		float posY = (*it).y;

		// Is the emitter near the player and make 500 pixel rect around the emitter
		FloatRect localRect(posX - 250, posY - 250, 500, 500);

		// Check if player is inside localRect
		if (m_Pixie.getPosition().intersects(localRect))
		{
			// Play sound and pass in location
			m_SM.playFire(Vector2f(posX, posY), m_Pixie.getCenter());
		}
	}

	// Set the appropriate view around the appropriate character
	if (m_SplitScreen)
	{
		m_LeftView.setCenter(m_Pixie.getCenter());
		m_RightView.setCenter(m_Trixie.getCenter());
	}
	else
	{
		// Centre full screen around appropriate character
		if (m_Character1)
		{
			m_MainView.setCenter(m_Pixie.getCenter());
		}
		else
		{
			m_MainView.setCenter(m_Trixie.getCenter());
		}
	}

	// Time to update the Hud
	// Increment the number of frames since
	// the last HUD calculation
	m_FramesSinceLastHUDUpdate++;

	// Update the HUD every m_TargetFramesPerHUDUpdate frames
	if (m_FramesSinceLastHUDUpdate > m_TargetFramesPerHUDUpdate)
	{
		// Update game HUD text
		stringstream ssTime;
		stringstream ssLevel;

		// Update time text
		ssTime << (int)m_TimeRemaining;
		m_Hud.setTime(ssTime.str());

		// Update level text
		ssLevel << "Level: " << m_LM.getCurrentLevel();
		m_Hud.setLevel(ssLevel.str());
		m_FramesSinceLastHUDUpdate = 0;
	}

	// Update the particles
	if (m_PS.running())
	{
		m_PS.update(dtAsSeconds);
	}
} // End of update function