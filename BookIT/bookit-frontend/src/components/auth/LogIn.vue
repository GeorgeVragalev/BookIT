<template>
  <div class="auth-container">
    <div class="auth-container__welcome-msg">welcome!</div>
    <div class="auth-container__welcome-msg--tiny">Login and let's get it started!</div>
    <el-form class="auth-container__form" :rules="rules" :model="user">
      <el-form-item prop="email">
        <el-input type="text" v-model="user.email" placeholder="Email"/>
      </el-form-item>
      <el-form-item prop="password">
        <el-input type="password" :showPassword="true" v-model="user.password" placeholder="Password"/>
      </el-form-item>
    </el-form>
    <el-button class="button--submit-auth-form"><i class="el-icon-right"/></el-button>
    <div class="auth-container__redirect">
      <router-link class="link" :to="{name: 'ForgotPassword'}">Forgot password?</router-link>
      <router-link class="link" :to="{name: 'Register'}">Create an account</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "LogIn",
  data() {
    return {
      user: {
        email: "",
        password: "",
      },
      showPassword: false,
      rules: {
        email: [
          {
            required: true,
            message: "Email is required",
            trigger: ["change", "blur"],
          },
          {
            type: 'email',
            message: "Invalid email type",
            trigger: ["change", "blur"],
          }
        ],
        password: [
          {
            required: true,
            message: "Password is required",
            trigger: ["change", "blur"],
          }
        ]
      }
    }
  }
}
</script>


<style scoped lang="scss">
.button--submit-auth-form {
  position: absolute;
  top: calc(15vh + 320px);
  left: calc(50% - 40px);
}

@media only screen and (max-width: 768px) {
  .button--submit-auth-form {
    top: calc(30vh + 242px);
  }
}
</style>