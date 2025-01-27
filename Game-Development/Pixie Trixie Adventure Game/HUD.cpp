#include "HUD.h"

Hud::Hud()
{
	Vector2u resolution;
	resolution.x = VideoMode::getDesktopMode().width;
	resolution.y = VideoMode::getDesktopMode().height;

	// Load the font
	m_Font.loadFromFile("fonts/Roboto-Light.ttf");

	// When paused
	m_StartText.setFont(m_Font);
	m_StartText.setCharacterSize(50);
	m_StartText.setFillColor(Color::Red);
	m_StartText.setString("Pixie & Trixie's Adventure, Enter to Start!");

	// Position text
	FloatRect textRect = m_StartText.getLocalBounds();

	m_StartText.setOrigin(textRect.left +
		textRect.width / 2.0f,
		textRect.top +
		textRect.height / 2.0f);

	m_StartText.setPosition(
		resolution.x / 2.0f, resolution.y / 2.0f);

	// Time
	m_TimeText.setFont(m_Font);
	m_TimeText.setCharacterSize(60);
	m_TimeText.setFillColor(Color::Cyan);
	m_TimeText.setPosition(resolution.x - 150, 0);
	m_TimeText.setString("------");

	// Level
	m_LevelText.setFont(m_Font);
	m_LevelText.setCharacterSize(60);
	m_LevelText.setFillColor(Color::Magenta);
	m_LevelText.setPosition(25, 0);
	m_LevelText.setString("1");
}

Text Hud::getMessage()
{
	return m_StartText;
}

Text Hud::getLevel()
{
	return m_LevelText;
}

Text Hud::getTime()
{
	return m_TimeText;
}

void Hud::setLevel(String text)
{
	m_LevelText.setString(text);
}

void Hud::setTime(String text)
{
	m_TimeText.setString(text);
}
