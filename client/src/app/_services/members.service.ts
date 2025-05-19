import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { Member } from '../_models/member';
import { of, tap } from 'rxjs';
import { Photo } from '../_models/photo';


@Injectable({
  providedIn: 'root'
})
export class MembersService {
  private Http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  members = signal<Member[]>([]);

  getMembers() {
    return this.Http.get<Member[]>(this.baseUrl + 'users').subscribe({
      next: members => this.members.set(members)
    })
  }

  getMember(username: string) {
    const member = this.members().find(x => x.username === username);
    if (member !== undefined) return of(member);

    return this.Http.get<Member>(this.baseUrl + 'users/' + username);
  }

  updateMember(member: Member) {
    return this.Http.put(this.baseUrl + 'users', member).pipe(
      tap(() => {
        this.members.update(members => members.map(m => m.username === member.username
          ? member : m))
      })
    )
  }

  setMainPhoto(Photo :Photo){
    return this.Http.put(this.baseUrl+ 'users/set-main-photo/' + Photo.id,{}).pipe(
      tap(() => {
        this.members.update(members => members.map(m =>{
          if (m.photos.includes(Photo)) {
            m.photoUrl = Photo.url
            
          }
          return m;
        }))
      })
    )
  }
  deletePhoto(photo:Photo){
    return this.Http.delete(this.baseUrl + 'users/delete-photo/'+photo.id).pipe(
      tap(() => {
        this.members.update(members => members.map(m =>{
          if(m.photos.includes(photo)){
            m.photos = m.photos.filter(x => x.id !== photo.id)
          }
          return m
        }))
      })
    )
  }
}
