<template>
  <div class="auth-container">
    <div class="auth-container__welcome-msg">Reset password</div>
    <div class="auth-container__welcome-msg--tiny">Hi<span v-if="email">, {{ email }}!</span></div>
    <el-form class="auth-container__form--register">
      <el-form-item prop="password">
        <el-input type="text" v-model="password" placeholder="Password"/>
      </el-form-item>
      <el-form-item prop="passwordConfirm">
        <el-input type="text" v-model="confirmPassword" placeholder="Confirm password"/>
      </el-form-item>
    </el-form>
    <el-button class="button--submit-auth-form"><i class="el-icon-right"/></el-button>
  </div>
</template>

<script>
export default {
  name: "ResetPasswordComponent",
  data() {
    return {
      email: "",
      password: "",
      confirmPassword: "",
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
  top: calc(15vh + 242px);
  left: calc(50% - 40px);
}

@media only screen and (max-width: 768px) {
  .button--submit-auth-form {
    top: calc(30vh + 180px);
  }
}
</style>