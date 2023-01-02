<template>
  <div class="auth-container">
    <div class="auth-container__welcome-msg">Forgot password?</div>
    <div class="auth-container__welcome-msg--tiny">No worries, just enter your email!</div>
    <el-form class="auth-container__form">
      <el-form-item>
        <el-input type="text" v-model="email" placeholder="Email"/>
      </el-form-item>
    </el-form>
    <el-button class="button--submit-auth-form"><i class="el-icon-right"/></el-button>
    <div class="auth-container__redirect">
        <router-link class="link" :to="{name: 'Login'}">Login</router-link>
        <router-link class="link" :to="{name: 'Register'}">Create an account</router-link>
      </div>
  </div>
</template>

<script>
export default {
  name: "ForgotPasswordComponent",
  data() {
    return {
      email: "",
    };
  }
}
</script>

<style scoped lang="scss">
.auth-container__welcome-msg {
  font-size: 1.7rem;

  &--tiny {
    font-size: 1rem;
  }
}

.button--submit-auth-form {
  position: absolute;
  top: calc(15vh + 253px);
  left: calc(50% - 40px);
}

@media only screen and (max-width: 768px) {
  .button--submit-auth-form {
    top: calc(30vh + 222px);
  }
}

</style>