//COMPLETE
package com.example.moviebuffs.ui

import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Star
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.layout.ContentScale
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextOverflow
import androidx.compose.ui.unit.dp
import coil.compose.AsyncImage
import coil.request.ImageRequest
import androidx.compose.ui.tooling.preview.Preview
import com.example.moviebuffs.data.PreviewData
import com.example.moviebuffs.ui.theme.MovieBuffsTheme
import com.example.moviebuffs.R
import com.example.moviebuffs.data.Movie

@Composable
fun MovieCard(
    modifier: Modifier = Modifier,
    movie: Movie,
    onMovieClick: (Movie) -> Unit,
) {
    Card(
        modifier = modifier
            .fillMaxWidth()
            .height(180.dp)
            .padding(top = 8.dp)
            .clickable { onMovieClick(movie) },
        elevation = CardDefaults.cardElevation(4.dp)
    ) {
        Row(
            modifier = Modifier.fillMaxWidth(),
            verticalAlignment = Alignment.CenterVertically
        ) {
            AsyncImage(
                model = ImageRequest.Builder(LocalContext.current)
                    .data(movie.imgSrc)
                    .crossfade(true)
                    .build(),
                contentDescription = null,
                modifier = Modifier
                    .width(120.dp)
                    .padding(end = 4.dp),
                contentScale = ContentScale.Crop,
                placeholder = painterResource(R.drawable.loading_img),
                error = painterResource(R.drawable.ic_broken_image)
            )
            Column(
                modifier = Modifier.padding(end = 2.dp)
            ) {
                Text(
                    text = movie.title,
                    style = MaterialTheme.typography.titleMedium,
                    fontWeight = FontWeight.Bold
                )
                Spacer(modifier = Modifier.height(4.dp))
                Text(
                    text = movie.description,
                    style = MaterialTheme.typography.bodyMedium,
                    maxLines = 4,
                    overflow = TextOverflow.Ellipsis,
                    modifier = Modifier.padding(end = 4.dp)
                )
                Spacer(modifier = Modifier.height(8.dp))
                Row(
                    modifier = Modifier.fillMaxWidth(),
                    verticalAlignment = Alignment.CenterVertically
                ) {
                    Icon(
                        imageVector = Icons.Filled.Star,
                        contentDescription = null,
                        tint = MaterialTheme.colorScheme.secondary,
                        modifier = Modifier.padding(end = 2.dp)
                    )
                    Text(
                        text = movie.rating,
                        style = MaterialTheme.typography.bodyMedium
                    )
                }
            }
        }
    }
}

@Preview(showBackground = true)
@Composable
fun MovieCardPreview() {
    MovieCard(
        movie = PreviewData.mockMovie,
        onMovieClick = {}
    )
}

@Preview(showBackground = true)
@Composable
fun MovieCardPreviewDark() {
    MovieBuffsTheme(darkTheme = true) {
        MovieCard(
            movie = PreviewData.mockMovie,
            onMovieClick = {}
        )
    }
}