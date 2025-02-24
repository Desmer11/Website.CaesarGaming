﻿namespace Website.CaesarGaming.Controllers

open System
open System.Diagnostics
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open Website.CaesarGaming.Models

type VideosController(logger: ILogger<VideosController>) =
    inherit Controller()

    // Method to display the list of videos
    member this.Index() =
        // Example model with a list of videos
        let videos = [
            { Id = 1; Title = "Video 1"; Description = "Description for Video 1"; Url = "/media/Videos/Video1.mp4" }
            { Id = 2; Title = "Video 2"; Description = "Description for Video 2"; Url = "/media/Videos/Video2.mp4" }
            { Id = 3; Title = "Video 3"; Description = "Description for Video 3"; Url = "/media/Videos/Video3.mp4" }
        ]
        this.View(videos)

    // Error handling method
    [<ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)>]
    member this.Error() =
        let reqId = 
            if isNull Activity.Current then
                this.HttpContext.TraceIdentifier
            else
                Activity.Current.Id

        this.View({ RequestId = reqId })
