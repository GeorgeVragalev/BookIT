<template>
  <div class="auth-container">
    <div class="auth-container__welcome-msg">Reset password</div>
    <div class="auth-container__welcome-msg--tiny">Hi<span v-if="user.email">, {{ user.email }}!</span></div>
    <el-form class="auth-container__form--register" :rules="rules" :model="user">
      <el-form-item prop="password">
        <el-input type="password" :showPassword="true" v-model="user.password" placeholder="Password"/>
      </el-form-item>
      <el-form-item prop="passwordConfirm">
        <el-input type="password" :showPassword="true" v-model="user.confirmPassword" placeholder="Confirm password"/>
      </el-form-item>
    </el-form>
    <el-button class="button--submit-auth-form"><i class="el-icon-right"/></el-button>
  </div>
</template>

<script>
export default {
  name: "ResetPasswordComponent",
  data() {
    const confirmPasswordValidator = (rule, value, callback) => {
      console.log(value)
      if (!this.user.confirmPassword) {
        callback(new Error("Please confirm password"));
      } else if (this.user.confirmPassword !== this.user.password) {
        callback(new Error("Confirm password does not match"));
      } else {
        callback();
      }
    }
    return {
      user: {
        email: "",
        password: "",
        confirmPassword: "",
      },
      rules: {
        password: [
          {
            required: true,
            message: "Password is required",
            trigger: ["change", "blur"],
          },
          {
            min: 8,
            message: "Password is too short",
            trigger: ["blur"],
          }
        ],
        passwordConfirm: [
          {
            validator: confirmPasswordValidator,
            trigger: ["blur"],
          }
        ],
      }
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
  top: calc(15vh + 255px);
  left: calc(50% - 40px);
}

@media only screen and (max-width: 768px) {
  .button--submit-auth-form {
    top: calc(30vh + 190px);
  }
}
</style>