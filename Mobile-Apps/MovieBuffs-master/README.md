# 🎥 Movie Buffs App

## 📖 Project Overview
The **Movie Buffs App** is the final project of the semester, combining a variety of Android development skills learned throughout the course. The app fetches a list of movies from a JSON endpoint, displays their details using adaptive layouts, implements material theming, and includes features like Coil for image loading, Retrofit for API integration, and more. The goal is to deliver a polished, responsive app that adheres to modern design practices.

---

## 🛠️ Features
- **API Integration**: Connects to the web service endpoint at `https://kareemy.github.io/MovieBuffs/movies.json` to fetch movie data.
- **Image Loading**: Uses Coil to download and display movie poster images.
- **Responsive UI**: Implements List-Detail adaptive layouts to ensure optimal user experience on different screen sizes, including tablets.
- **Error Handling**: Displays loading and error screens with a Retry button for better usability.
- **Material Theming**: Applies a custom material theme and a branded app icon for a professional look.

---

## ✅ Requirements Fulfilled
### 🌐 Internet Connectivity
- Integrated Retrofit and kotlinx.serialization for API calls.
- Built `ViewModel` to manage app state and handle data fetching.
- Implemented loading and error states with retry functionality.

### 🎨 UI Design
- Designed `MovieCard` and `MoviesList` composables using Jetpack Compose.
- Created a `MoviesDetail` screen to show detailed information about each movie.
- Added previews for `MovieCard`, `MoviesList`, and `MoviesDetail` composables using mock data.

### 🔄 Navigation
- Enabled navigation between the List screen and Details screen by clicking a `MovieCard`.
- Added a back arrow in the `TopAppBar` to navigate from Details back to List.
- Implemented `BackHandler` for proper back navigation.

### 📱 Adaptive Layout
- Used `WindowSizeClass` to display List-Detail layouts in expanded mode for larger screens.
- Tested on a resizable device to ensure responsive design.

### 🎨 Material Theming
- Created a custom material theme using the Material Theme Builder.
- Customized the app icon using the provided SVG image and specified colors.

---

## 📚 Resources Used
- **Web Service Endpoint**: [Movies JSON](https://kareemy.github.io/MovieBuffs/movies.json)
- **Loading Image**: [loading_img.xml](https://kareemy.github.io/Mars/loading_img.xml)
- **Error Icons**:
  - [ic_broken_image.xml](https://kareemy.github.io/Mars/ic_broken_image.xml)
  - [ic_connection_error.xml](https://kareemy.github.io/Mars/ic_connection_error.xml)
- **App Icon**: [moviebuffs-icon.svg](https://kareemy.github.io/MovieBuffs/moviebuffs-icon.svg)

---

## 🛠️ How to Build and Run
1. Clone the repository and open the project in **Android Studio**.
2. Update all Gradle dependencies to the latest versions.
3. Implement the following dependencies:
   - `retrofit`
   - `kotlinx.serialization`
   - `coil`
4. Ensure the app is connected to the internet and able to fetch data from the JSON endpoint.
5. Build and run the app to test the UI, navigation, and functionality across various screen sizes.

---

## 🧪 Testing
- Tested in both **Compact** and **Expanded** modes to ensure responsive design.
- Verified error states and retry functionality by simulating offline scenarios.
- Ensured consistent theming across all screens with the custom material design.

---

## 📸 Screenshots and Animations
- **List Screen** and **Details Screen** examples: Refer to the provided screenshots.
- **Adaptive Layout** for Expanded mode: Demonstrated in animated examples.
- **Animations**:  
  - ![Animation 1](https://kareemy.github.io/moviebuffs-anim1.gif)  
  - ![Animation 2](https://kareemy.github.io/moviebuffs-anim2.gif)

---

## 📝 Notes
- Followed best practices from course modules, including the **Mars Photos app**, **Dinosaurs app**, and **Sports app** for adaptive layouts and API integration.
- Material Theming guidelines were implemented as per Module 10 instructions.

---

This project demonstrates the ability to build a feature-rich Android app using modern tools and techniques. It serves as a comprehensive showcase of skills acquired during the semester.
