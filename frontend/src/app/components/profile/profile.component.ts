import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, RouterOutlet} from '@angular/router';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../Services/user.service';
import { HeaderComponent } from '../header/header.component';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [RouterLink,RouterOutlet,FormsModule,HeaderComponent,CommonModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userid:any 
  ProfileName:any 
  ngOnInit(): void {
    this.userid = localStorage.getItem('userId')
    this.getDetails(this.userid)
    console.log(this.userid)
  }
  constructor(private userService:UserService,private toastr:ToastrService){} //private toastr:ToastrService
  
  UserObj: any = {
    name: "",
    email: "",
    phone: "",
    address: "",
  }
  isEditingProfile=false
  http = inject(HttpClient)

  getDetails(id: string) {
    this.http.get("https://localhost:7002/api/UserClasses/"+id).subscribe((res:any)=>{
      console.log(res)
      if(res){
        this.UserObj=res
        console.log(this.UserObj)
      }
    })
    this.userService.getUserById(id).subscribe((res: any) => {
     
      
    })
  }
  cancelProfileEdit(){this.isEditingProfile=false}
  enableProfileEdit(){this.isEditingProfile=true}
  onProfileSubmit() {
  this.userService. updateUserProfile(this.userid,this.UserObj).subscribe((res:any)=>{
    console.log(res)
    if (res) {
      // this.toastr.success("Successfully updated details")
      this.toastr.success('user updated')
    }
    this.isEditingProfile=false
  })
  }
  onLogOut(){
    localStorage.clear()
  }
}