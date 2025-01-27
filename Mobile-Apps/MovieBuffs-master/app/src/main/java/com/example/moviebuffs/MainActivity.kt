//COMPLETE
package com.example.moviebuffs

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.viewModels
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.material3.windowsizeclass.ExperimentalMaterial3WindowSizeClassApi
import androidx.compose.ui.Modifier
import androidx.compose.material3.windowsizeclass.calculateWindowSizeClass
import com.example.moviebuffs.ui.MovieBuffsApp
import com.example.moviebuffs.ui.MovieViewModel
import com.example.moviebuffs.ui.theme.MovieBuffsTheme

class MainActivity : ComponentActivity() {
    private val viewModel: MovieViewModel by viewModels()

    @OptIn(ExperimentalMaterial3WindowSizeClassApi::class)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            MovieBuffsTheme {
                Surface(
                    modifier = Modifier.fillMaxSize(),
                    color = MaterialTheme.colorScheme.background
                ) {
                    val windowSize = calculateWindowSizeClass(this)
                    MovieBuffsApp(
                        windowSize = windowSize,
                        viewModel = viewModel
                    )
                }
            }
        }
    }
}