//COMPLETE
package com.example.moviebuffs.ui

import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.moviebuffs.data.Movie
import com.example.moviebuffs.data.MovieApi
import kotlinx.coroutines.launch
import java.io.IOException
import retrofit2.HttpException

sealed interface MoviesUiState {
    data class Success(val movies: List<Movie>) : MoviesUiState
    object Error : MoviesUiState
    object Loading : MoviesUiState
}

data class MovieNavigationState(
    val currentMovie: Movie? = null,
    val isShowingListPage: Boolean = true
)

class MovieViewModel : ViewModel() {
    var moviesUiState: MoviesUiState by mutableStateOf(MoviesUiState.Loading)
        private set

    var navigationState: MovieNavigationState by mutableStateOf(MovieNavigationState())
        private set

    init {
        getMovies()
    }

    fun getMovies() {
        viewModelScope.launch {
            moviesUiState = MoviesUiState.Loading
            moviesUiState = try {
                MoviesUiState.Success(
                    MovieApi.retrofitService.getMovies()
                )
            } catch (e: IOException) {
                MoviesUiState.Error
            } catch (e: HttpException) {
                MoviesUiState.Error
            }
        }
    }

    fun updateCurrentMovie(movie: Movie) {
        navigationState = navigationState.copy(
            currentMovie = movie,
            isShowingListPage = false
        )
    }

    fun navigateBack() {
        navigationState = navigationState.copy(isShowingListPage = true)
    }
}