//COMPLETE
package com.example.moviebuffs.ui

import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.unit.dp
import androidx.compose.ui.tooling.preview.Preview
import com.example.moviebuffs.data.PreviewData
import com.example.moviebuffs.ui.theme.MovieBuffsTheme
import com.example.moviebuffs.R
import com.example.moviebuffs.data.Movie

@Composable
fun MoviesList(
    movies: List<Movie>,
    onMovieClick: (Movie) -> Unit,
    modifier: Modifier = Modifier
) {
    LazyColumn(
        modifier = modifier
            .padding(4.dp)
            .fillMaxWidth()
    ) {
        items(movies) { movie ->
            MovieCard(
                movie = movie,
                onMovieClick = onMovieClick
            )
        }
    }
}

@Composable
fun LoadingScreen(modifier: Modifier = Modifier) {
    Image(
        modifier = modifier.size(200.dp),
        painter = painterResource(R.drawable.loading_img),
        contentDescription = "Loading"
    )
}

@Composable
fun ErrorScreen(
    onRetry: () -> Unit,
    modifier: Modifier = Modifier
) {
    Column(
        modifier = modifier.fillMaxSize(),
        verticalArrangement = Arrangement.Center,
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        Image(
            painter = painterResource(id = R.drawable.ic_connection_error),
            contentDescription = null,
            modifier = Modifier.size(64.dp)
        )
        Text(
            text = "Failed to load",
            modifier = Modifier.padding(16.dp)
        )
        Button(onClick = onRetry) {
            Text("Retry")
        }
    }
}

@Preview(showBackground = true)
@Composable
fun MoviesListPreview() {
    MoviesList(
        movies = PreviewData.mockMoviesList,
        onMovieClick = {}
    )
}

@Preview(showBackground = true)
@Composable
fun MoviesListPreviewDark() {
    MovieBuffsTheme(darkTheme = true) {
        MoviesList(
            movies = PreviewData.mockMoviesList,
            onMovieClick = {}
        )
    }
}