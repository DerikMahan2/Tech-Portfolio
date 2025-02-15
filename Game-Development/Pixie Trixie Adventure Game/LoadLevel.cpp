#include "Engine.h"

void Engine::loadLevel()
{
	m_Playing = false;

	// Delete the previously allocated memory
	for (int i = 0; i < m_LM.getLevelSize().y; i++)
	{
		delete[] m_ArrayLevel[i];
	}
	delete[] m_ArrayLevel;

	// Load the next 2D array with map for the level
	// and repopulate the vertex array as well
	m_ArrayLevel = m_LM.nextLevel(m_VALevel);

	// Prepare the sound emitters
	populateEmitters(m_FireEmitters, m_ArrayLevel);

	// How long is this new time limit
	m_TimeRemaining = m_LM.getTimeLimit();

	// Spawn Pixie and Trixie
	m_Pixie.spawn(m_LM.getStartPosition(), GRAVITY);
	m_Trixie.spawn(m_LM.getStartPosition(), GRAVITY);

	// Make sure this code isn't ran again
	m_NewLevelRequired = false;
}