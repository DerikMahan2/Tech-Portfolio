//COMPLETE
package com.example.moviebuffs.ui

import androidx.activity.compose.BackHandler
import androidx.compose.foundation.layout.*
import androidx.compose.material3.windowsizeclass.WindowSizeClass
import androidx.compose.material3.windowsizeclass.WindowWidthSizeClass
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import com.example.moviebuffs.data.Movie

@Composable
fun MoviesListAndDetails(
    windowSize: WindowSizeClass,
    moviesUiState: MoviesUiState,
    navigationState: MovieNavigationState,
    onMovieClick: (Movie) -> Unit,
    retryAction: () -> Unit,
    modifier: Modifier = Modifier
) {
    BackHandler(enabled = !navigationState.isShowingListPage) {
        retryAction()
    }

    when (windowSize.widthSizeClass) {
        WindowWidthSizeClass.Expanded -> {
            Row(modifier = modifier.fillMaxSize()) {
                Box(modifier = Modifier.weight(2f)) {
                    MovieScreenContent(
                        moviesUiState = moviesUiState,
                        onMovieClick = onMovieClick,
                        retryAction = retryAction,
                        modifier = Modifier.padding(start = 16.dp, end = 16.dp)
                    )
                }
                Box(modifier = Modifier.weight(3f)) {
                    navigationState.currentMovie?.let { movie ->
                        MovieDetail(movie = movie)
                    }
                }
            }
        }
        else -> {
            if (navigationState.isShowingListPage) {
                MovieScreenContent(
                    moviesUiState = moviesUiState,
                    onMovieClick = onMovieClick,
                    retryAction = retryAction
                )
            } else {
                navigationState.currentMovie?.let { movie ->
                    MovieDetail(movie = movie)
                }
            }
        }
    }
}

@Composable
private fun MovieScreenContent(
    moviesUiState: MoviesUiState,
    onMovieClick: (Movie) -> Unit,
    retryAction: () -> Unit,
    modifier: Modifier = Modifier
) {
    when (moviesUiState) {
        is MoviesUiState.Loading -> LoadingScreen(modifier = modifier)
        is MoviesUiState.Success -> MoviesList(
            movies = moviesUiState.movies,
            onMovieClick = onMovieClick,
            modifier = modifier
        )
        is MoviesUiState.Error -> ErrorScreen(
            onRetry = retryAction,
            modifier = modifier
        )
    }
}