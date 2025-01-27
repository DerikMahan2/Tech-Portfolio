//COMPLETE
package com.example.moviebuffs.data

import kotlinx.serialization.SerialName
import kotlinx.serialization.Serializable

@Serializable
data class Movie(
    val title: String,
    @SerialName("poster")
    val imgSrc: String,
    val description: String,
    @SerialName("release_date")
    val releaseDate: String,
    @SerialName("content_rating")
    val contentRating: String,
    @SerialName("review_score")
    val rating: String,
    @SerialName("big_image")
    val bigImage: String,
    val length: String
)

object PreviewData {
    val mockMovie = Movie(
        title = "Sample Movie",
        imgSrc = "",
        description = "This is a sample movie description that spans multiple lines to show how the UI handles longer text.",
        releaseDate = "July 1, 2023",
        contentRating = "PG-13",
        rating = "7.5",
        bigImage = "",
        length = "2h 15m"
    )

    val mockMoviesList = listOf(
        mockMovie,
        mockMovie.copy(title = "Second Movie")
    )
}