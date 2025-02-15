#include "Engine.h"

void Engine::input()
{
	Event event;
	while (m_Window.pollEvent(event))
	{
		if (event.type == Event::KeyPressed)
		{


			// Handle the player quitting
			if (Keyboard::isKeyPressed(Keyboard::Escape))
			{
				m_Window.close();
			}

			// Handle the player starting the game
			if (Keyboard::isKeyPressed(Keyboard::Return))
			{
				m_Playing = true;
			}

			// Switch between Pixie and Trixie
			if (Keyboard::isKeyPressed(Keyboard::Q))
			{
				m_Character1 = !m_Character1;
			}

			// Switch between full and split-screen
			if (Keyboard::isKeyPressed(Keyboard::E))
			{
				m_SplitScreen = !m_SplitScreen;
			}
		}
	}

	// Handle input specific to Pixie
	if (m_Pixie.handleInput())
	{
		// Play a jump sound
		m_SM.playJump();
	}

	// Handle input specific to Trixie
	if (m_Trixie.handleInput())
	{
		// Play a jump sound
		m_SM.playJump();
	}
}