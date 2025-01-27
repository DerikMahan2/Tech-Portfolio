#include "Engine.h"

bool Engine::detectCollisions(PlayableCharacter& character)
{
	bool reachedGoal = false;
	// Make a rect for all its parts
	FloatRect detectionZone = character.getPosition();

	// Make a FloatRect to test each block
	FloatRect block;

	block.width = TILE_SIZE;
	block.height = TILE_SIZE;

	// Build a zone around Pixie to detect collisions.
	int startX = (int)(detectionZone.left / TILE_SIZE) - 1;
	int startY = (int)(detectionZone.top / TILE_SIZE) - 1;
	int endX = (int)(detectionZone.left / TILE_SIZE) + 2;

	// Pixie is quite tall so check a few tiles vertically
	int endY = (int)(detectionZone.top / TILE_SIZE) + 3;
	// Make sure we dont check negative number positions
	// or past the end of the array
	if (startX < 0) startX = 0;
	if (startY < 0) startY = 0;
	if (endX >= m_LM.getLevelSize().x)
		endX = m_LM.getLevelSize().x;
	if (endY >= m_LM.getLevelSize().y)
		endY = m_LM.getLevelSize().y;

	// Has the character fallen off the map
	FloatRect level(0, 0,
		m_LM.getLevelSize().x * TILE_SIZE,
		m_LM.getLevelSize().y * TILE_SIZE);

	if (!character.getPosition().intersects(level))
	{
		// Respawn the character
		character.spawn(m_LM.getStartPosition(), GRAVITY);
	}

	// Loops through all the local blocks
	for (int x = startX; x < endX; x++)
	{
		for (int y = startY; y < endY; y++)
		{
			// Initialize the starting position of the current block
			block.left = x * TILE_SIZE;
			block.top = y * TILE_SIZE;

			// Check if character has been burnt or drowned
			if (m_ArrayLevel[y][x] == 2 || m_ArrayLevel[y][x] == 3)
			{
				if (character.getHead().intersects(block))
				{
					character.spawn(m_LM.getStartPosition(), GRAVITY);
					// Pick what sound plays here
					if (m_ArrayLevel[y][x] == 2) // Fire level
					{
						// Play fire sounds
						m_SM.playFallInFire();
					}
					else // Water
					{
						// Play Water sounds
						m_SM.playFallInWater();
					}
				}
			}

			// Check for player colliding with a regular block
			if (m_ArrayLevel[y][x] == 1)
			{
				if (character.getRight().intersects(block))
				{
					character.stopRight(block.left);
				}
				else if (character.getLeft().intersects(block))
				{
					character.stopLeft(block.left);
				}

				if (character.getFeet().intersects(block))
				{
					character.stopFalling(block.top);
				}
				else if (character.getHead().intersects(block))
				{
					character.stopJump();
				}
			}

			// More collision detection here once I learn
			// about particle effects
			// Have the character's feet touched the fire or water?
			// If so start the particle effects
			// Check to make sure this is the first time ran
			if (!m_PS.running()) {
				if (m_ArrayLevel[y][x] == 2 || m_ArrayLevel[y][x] == 3)
				{
					if (character.getFeet().intersects(block))
					{
						// position and start the particle system
						m_PS.emitParticles(character.getCenter());
					}
				}
			}

			// Check if player reaches goal
			if (m_ArrayLevel[y][x] == 4)
			{
				// Player did reach goal
				reachedGoal = true;
			}
		}

		
	}

	// Return if player reached goal or not
	return reachedGoal;
}