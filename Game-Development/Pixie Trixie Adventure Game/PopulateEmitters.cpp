#include "Engine.h"

using namespace sf;
using namespace std;

void Engine::populateEmitters(
	vector <Vector2f>& vSoundEmitters,
	int** arrayLevel)
{
	// Empty the vector
	vSoundEmitters.empty();

	// Track the emitter to no make to many
	FloatRect previousEmitter;

	// Search for fire in level
	for (int x = 0; x < (int)m_LM.getLevelSize().x; x++)
	{
		for (int y = 0; y < (int)m_LM.getLevelSize().y; y++)
		{
			if (arrayLevel[y][x] == 2) // fire is present
			{
				// Skip any fire tiles next to previous emitter
				if (!FloatRect(x * TILE_SIZE,
					y * TILE_SIZE,
					TILE_SIZE,
					TILE_SIZE).intersects(previousEmitter))
				{
					// Add coordinates of water block
					vSoundEmitters.push_back(
						Vector2f(x * TILE_SIZE, y * TILE_SIZE));

					// make rectangle 6x6 to not make to many emitters close to this one
					previousEmitter.left = x * TILE_SIZE;
					previousEmitter.top = y * TILE_SIZE;
					previousEmitter.width = TILE_SIZE * 6;
					previousEmitter.height = TILE_SIZE * 6;
				}
			}
		}
	}
	return;
}