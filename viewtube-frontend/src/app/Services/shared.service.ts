import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  videoIdIs : any
  favVideoList:any =[]
  constructor() { }

  setVideoId(videoId){
    this.videoIdIs = videoId;
  }

  getVideoId(){
    return this.videoIdIs;
  }
  addToFavourite(videoDetails){
//this.favVideoList.push(thumbnail,videoTitle,channelTitle,videoId);
    // this.favVideoList=thumbnail;
    // //videoTitle,channelTitle,videoId;
    // this.favVideoList=videoTitle;
    // this.favVideoList=videoId;
    // this.favVideoList=channelTitle;
    this.favVideoList.push (videoDetails);
  }
  getFavourites(){
   return this.favVideoList;
 }
}
