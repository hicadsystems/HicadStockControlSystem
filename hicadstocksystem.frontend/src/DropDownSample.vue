<template>
    <div class="p-5 grid grid-cols-12 gap-4 row-gap-3">
        
        <div v-if="errors" class="has-error"> {{ [errors] }}</div>
        <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
            <!-- <div class="col-span-12 sm:col-span-6">

          <input type="text" v-model="postBody.NewApplicantNumber" v-show="show" class="input w-full border mt-2 flex-1"/>
         </div>
        </div>-->
            <div class="col-span-12 sm:col-span-6">

                <input type="text" class="input w-full border mt-2 flex-1" 
                name="surName " v-model="postBody.surName" placeholder="Surname" />

            </div>
            <div class="col-span-12 sm:col-span-6">

                <input type="text" class="input w-full border mt-2 flex-1" 
                name="otherName" v-model="postBody.otherName" placeholder="Othername" />

            </div>

            <div class="col-span-12 sm:col-span-6">

                <select class="input w-full border mt-2 flex-1" v-model="postBody.category" name="category" placeholder="Category" required>
                    <option v-for="caty in categoryList" v-bind:value="caty.categoryCode" v-bind:key="caty.categoryCode"> {{ caty.categoryName }} </option>
                </select>


            </div>
            <div class="col-span-12 sm:col-span-6">

                <input type="text" class="input w-full border mt-2 flex-1" name="userName" v-model="postBody.userName" placeholder="Username" />

            </div>

            <div class="col-span-12 sm:col-span-6">

                <input type="password" class="input w-full border mt-2 flex-1" name="password" v-model="postBody.password" placeholder="*********" />

            </div>
            <div class="col-span-12 sm:col-span-6">

                <input type="email" class="input w-full border mt-2 flex-1" name="email" v-model="postBody.email" placeholder="Email" />

            </div>


            <div class="col-span-12 sm:col-span-6">

                <input type="text" class="input w-full border mt-2 flex-1" name="phone" v-model="postBody.phone" placeholder="Phone" />

            </div>
            <div class="col-span-12 sm:col-span-6">

                <input type="text" class="input w-full border mt-2 flex-1" name="applicationPin" v-model="postBody.applicationPin" placeholder="Application pin" />

            </div>

            <div class="col-span-12 sm:col-span-6">

                <select class="input w-full border mt-2 flex-1" v-model="postBody.status" name="status" placeholder="status" required>
                    <option v-for="caty in statusList" v-bind:value="caty.statusName" v-bind:key="caty.id"> {{ caty.statusName }} </option>
                </select>

            </div>


            <div class="btn-group mr-2 sw-btn-group-extra" v-if="canProcess" role="group">
                <button class="btn btn-submit btn-primary" v-on:click="checkForm" type="button">{{submitorUpdate}}</button>
            </div>
    </div>
				
</template>
<script>
export default{
     data() {
        return {
            errors: null,
            responseMessage:'',
            submitorUpdate : 'Submit',
            canProcess : true,
            categoryList:null,
            statusList:null,
            checkLogin:null,
            show:false,
            postBody: {
                NewApplicantNumber:'',
                surName :'',
                otherName:'',
                category:'',
                userName:'',
                password:'',
                email:'',
                phone:'',
                applicationPin:'',
                status:''
            }
        }
        },
        mounted(){
            // axios.get(`/api/NewApplicant/GenerateApplicantNo`)
            //            then(response=>{
            //               this.postBody.NewApplicantNumber=response.data
            //  });
           axios.get(`/api/category/getAllCategory`)
           .then(response=>{
               this.categoryList= response.data
           })
           axios.get(`/api/Status/GetAllStatus`)
           .then(response=>{
               this.statusList= response.data
           })
        //    axios.get(`/api/NewApplicant/GenerateApplicantNo`)
        //    .then(response=>{
        //        this.postBody.NewApplicantNumber=response.data
        //    })
        },
        watch: {
            '$store.state.objectToUpdate': function (newVal, oldVal) {
                this.postBody.NewApplicantNumber = this.$store.state.objectToUpdate.NewApplicantNumber,
                this.postBody.surName= this.$store.state.objectToUpdate.surName,
                this.postBody.otherName = this.$store.state.objectToUpdate.otherName,
                this.postBody.category = this.$store.state.objectToUpdate.category
                 this.postBody.userName = this.$store.state.objectToUpdate.userName,
                this.postBody.password = this.$store.state.objectToUpdate.password,
                this.postBody.email = this.$store.state.objectToUpdate.email,
                this.postBody.phone = this.$store.state.objectToUpdate.phone,
                this.postBody.applicationPin=this.$store.state.objectToUpdate.applicationPin,
                this.postBody.status=this.$store.state.objectToUpdate.status,
                this.submitorUpdate = 'Update';

            }
        },
        methods: {
            // getChecked(){
            //     if(canLogin){
            //       this.canLogin=1;
            //    }else{
            //          this.canLogin=0;
            //    }
             
            // },
            checkForm: function (e) {
              
                if (this.postBody.surName && this.postBody.otherName && this.postBody.email) {
                   // e.preventDefault();
                   
                    this.canProcess = false;
                    this.postPost();
                }
                else {
                    this.errors = [];
                    this.errors.push('Supply the respective value ');
                }
            },
            updateApplicantNo(){
            //    axios.get(`/api/NewApplicant/updateAplicantNo/${this.postBody.NewApplicantNumber}`)
            //    .then(response=>{
            //        if(response.data.responseCode==200){
            //            console.log(response.data.responseDescription);
            //        }
            //    })
            alert("i am there");
            },
            postPost() {
                if (this.submitorUpdate == 'Submit') {
                    axios.post(`/api/NewApplicant/createNewApplicant`, this.postBody)
                        .then(response => {
                            this.responseMessage = response.data.responseDescription; 
                            this.canProcess = true;
                            if (response.data.responseCode == '200') {

                                this.postBody.NewApplicantNumber = '';
                                this.postBody.surName = '';
                                this.postBody.otherName = '';
                                this.postBody.category = '';
                                this.postBody.userName='';
                                this.postBody.password='';
                                this.postBody.email='';
                                this.postBody.phone='';
                                this.postBody.applicationPin='';
                                this.postBody.status='';
                                this.$store.state.objectToUpdate = "create";
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        });
                }
                if (this.submitorUpdate == 'Update') {
                    axios.put(`/api/NewApplicant/updateNewApplicant`, this.postBody)
                        .then(response => {
                            this.responseMessage = response.data.responseDescription; this.canProcess = true;
                            if (response.data.responseCode == '200') {
                                this.submitorUpdate = 'Submit'
                                this.postBody.NewApplicantNumber = '';
                                this.postBody.surName = '';
                                this.postBody.otherName = '';
                                this.postBody.category = '';
                                this.postBody.userName='';
                                this.postBody.password='';
                                this.postBody.email='';
                                this.postBody.phone='';
                                this.postBody.applicationPin='';
                                this.postBody.status='';
                                this.$store.state.objectToUpdate = "update";
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        });
                }
            }
        },
        computed: {
            setter() {
                let objecttoedit = this.$store.state.objectToUpdate;
                if (objecttoedit.NewApplicantNumber) {
                     this.postBody.NewApplicantNumber = objecttoedit.NewApplicantNumber;
                     this.postBody.surName=objecttoedit.surName;
                     this.postBody.otherName=objecttoedit.otherName;
                     this.postBody.category=objecttoedit.category;
                     this.postBody.userName=objecttoedit.userName;
                     this.postBody.password=objecttoedit.password;
                     this.postBody.email=objecttoedit.email;
                     this.postBody.phone=objecttoedit.phone;
                     this.postBody.applicationPin=objecttoedit.applicationPin;
                     this.postBody.status=objecttoedit.status;
                    
                }
            }
        }

};
</script>